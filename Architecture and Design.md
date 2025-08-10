# Multi-Tenant Order Management System - High-Level System Design

## 1. Architecture Overview

This system is designed to serve multiple tenants (clients/organizations) within a single deployment, enabling cost efficiency and simplified management while ensuring strong data isolation and scalability. It follows Clean Architecture principles to maintain separation of concerns, testability, and flexibility for future enhancements.

### Application Layers

- **Presentation Layer (API)**  
  Exposes RESTful endpoints to tenants for order management (e.g., orders, users, reports).
  
- **Application Layer**  
  Handles business logic and use cases.

- **Domain Layer**  
  Contains domain entities, and domain services.

- **Infrastructure Layer**  
  Implements persistence (database interactions using Entity Framework Core), external APIs, authentication, logging, and email notifications.

<img width="1100" height="1093" alt="image" src="https://github.com/user-attachments/assets/1a2513fa-abf0-46a3-8268-8515c20705ea" />

### Multitenancy Approach

- **Shared Schema, Tenant Discriminator Column**  
  A single database with shared tables. Each record is associated with a `TenantId`. EF Core filters are used to enforce tenant scoping.

  Pros:
  - Cost-effective
  - Easier to maintain
  - Scales well for a medium number of tenants

  Cons:
  - Higher complexity for isolation and data access control

<img width="525" height="654" alt="image" src="https://github.com/user-attachments/assets/159bf836-5c4a-4d26-ace5-7551e6362fa8" />

> Alternatively, the design allows switching to **Schema-per-Tenant** for premium customers if needed.

### API Structure

- **Versioned REST API**  
/api/v1/{tenantId}/orders
/api/v1/{tenantId}/users
- Authenticated access via OAuth2 / OpenID Connect (Azure AD B2C or IdentityServer)
- Middleware for extracting and validating `TenantId` from URL

### Hosting Strategy

- **Azure App Services** (default for lower operational overhead)
- **Dockerized** .NET apps for containerization, enabling:
- Azure Kubernetes Service (AKS) for advanced scaling needs
- Easier CI/CD pipelines and local development consistency

---

## 2. Technology Stack

### Backend
- **.NET 9 Web API**
- **Entity Framework Core**
- **FluentValidation** for validation
- **AutoMapper** for DTO mapping

### Database
- **Azure SQL Database** Shared databases that auto-scale resources based on tenant needs for cost and performance efficiency.
- **Redis Cache** In-memory caching to speed up common data lookups and reduce database load.
- **Blob Storage** Scalable storage for documents and files, keeping the database optimized and improving performance.

### CI/CD Tools
- **Azure DevOps Pipelines** for build, test, and release
- **Bicep / ARM Templates** for infrastructure as code

### Logging, Monitoring, Testing Tools
- **Serilog + Azure Application Insights** for centralized logging
- **Health Checks** via `.NET HealthChecks` and Azure Monitor
- **xUnit + Moq** for unit testing
- **Postman** for integration and API tests

---

## 3. Key Considerations

### Enforcing Tenant Isolation

- Middleware-based `TenantContext` extracted from URL route parameter (instead of JWT or headers)
- Global query filters in EF Core using `HasQueryFilter(x => x.TenantId == tenantId)`
- Row-level security (RLS) in Azure SQL (if needed)
- Scoped services per tenant in DI container

### Scalability & Performance

- **Horizontal scaling** of App Services or AKS pods (Add more app instances or pods to handle increased traffic and improve availability)
- **Elastic pools** for Azure SQL to auto-scale based on tenant activity (Dynamically share and scale database resources across tenants based on their usage)
- **Caching** with Redis to reduce DB load (Store frequent data in memory to speed up responses and reduce database queries)
- **Asynchronous background jobs** using Azure Functions (Run background tasks asynchronously to keep the app responsive and scalable)

### DevOps & Deployment Strategy

- **Branching strategy:**
A structured Git workflow that uses specific branches for features, releases, hotfixes, and development, helping teams manage parallel work and release cycles smoothly.
- **Environments:** (Dev → QA → Staging → Production)
A sequence of deployment environments where code is progressively tested and validated:
1. Dev: Developers integrate and test new code
1. QA: Quality assurance team tests functionality and finds bugs
1. Staging: A production-like environment for final validation before release
1. Production: The live environment accessed by end users
- **Blue/Green deployment** for minimal downtime
A deployment strategy where two identical environments (blue and green) are maintained; new releases go to the inactive one, then traffic switches over instantly, minimizing downtime and rollback risk.

### Team Structure and Responsibilities

| Role | Responsibility |
|------|----------------|
| Tech Lead | System architecture, code reviews, DevOps guidance |
| Backend Developers | Build API, domain logic, unit tests |
| DevOps Engineer | Setup CI/CD, infrastructure as code, monitoring |
| QA Engineer | Create and run test cases (manual and automated) |
| Product Owner | Define features, roadmap, priority |
| Scrum Master | Facilitate agile ceremonies and delivery |

---
