# Exquitech-Assessment

A solution to Exquitech's assessment.

# Order Management Solution

A RESTful API for managing orders, built with **ASP.NET Core** (.NET 9, C# 13).

## Table of Contents

- [Overview](#overview)
- [Setup & Run Instructions](#setup--run-instructions)
- [Architectural Decisions](#architectural-decisions)
- [Assumptions](#assumptions)
- [Deployed API (Azure App Service)](#deployed-api-azure-app-service)
- [Postman Collection](#postman-collection)
- [API Endpoints](#api-endpoints)
- [Extensibility & Future Work](#extensibility--future-work)
- [Contact](#contact)

---

## Overview

This project provides an Order Management API designed with best practices in mind. The API enables the creation, retrieval, and management of customer orders, supporting multi-tenancy and ready for extension with features like authentication, advanced validation.

---

## Setup & Run Instructions

1. **Prerequisites:**
   - [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
   - (Optional) [SQLite](https://www.sqlite.org/download.html) if you want to directly inspect the database file.

2. **Clone the repository:**
   ```sh
   git clone https://github.com/hamza-kanaan/Exquitech-Assessment.git
   cd Exquitech-Assessment
   ```

3. **Restore dependencies:**
   ```sh
   dotnet restore
   ```

4. **Build the solution:**
   ```sh
   dotnet build
   ```

5. **Run the API:**
   ```sh
   dotnet run --project OrderManagement.Api
   ```
   The API will be available at `https://localhost:7142`.

6. **Swagger UI:**
   - Navigate to `https://localhost:7142/swagger` to access interactive API documentation and test endpoints.

7. **Run Tests:**
   ```sh
   dotnet test
   ```

---

## Architectural Decisions

- **Clean Architecture**: Promotes separation of concerns and testability by splitting the solution into four layers:
  - **Domain**: Entities and Interfaces.
  - **Application**: Business use cases, DTOs.
  - **Infrastructure**: Implementation details (e.g., EF Core, logging).
  - **API**: Presentation layer (controllers, middleware, etc.).
- **Dependency Injection:** Services are injected via constructor for testability and maintainability.
- **DTO Usage:** Data Transfer Objects (DTOs) are used to decouple API contracts from domain models.
- **Async/Await:** All I/O and service calls are asynchronous for improved scalability.
- **RESTful Endpoints:** All endpoints adhere to REST conventions (resource-based URIs, HTTP methods).
- **Entity Framework Core:** Used with SQLite for demonstration; can be configured for other providers.
- **Serilog:** Provides enriched, structured logging for easier monitoring and troubleshooting.
- **FluentValidation:** Centralized, expressive validation for DTOs and input models.
- **AutoMapper:** Simplifies the mapping between domain entities and DTOs.
- **Swagger/OpenAPI:** Automatically generates comprehensive API documentation.
- **Custom Middleware:** Handles global exception handling and tenant resolution.

---

## Assumptions

- **Authentication & Authorization**: Not implemented in this version. All endpoints are open.
- **Input Validation**: Basic validation is implemented; more complex business rules can be added as needed.
- **Data Store**: Abstracted through EF Core; SQLite is used for demo purposes but can easily be replaced.
- **Database Migrations**: The database schema is automatically migrated at application startup.
- **Multi-Tenancy**: Assumes tenant identification is via middleware.
- **User Registration**: Checks for existing users by email to prevent duplicates.
- **Logging**: All actions (success and failure) are logged for auditability.

---

## Deployed API (Azure App Service)

- **Base URL:** [`https://ordermangementapi.azurewebsites.net`](https://ordermangementapi.azurewebsites.net)
- **Swagger Docs:** [`https://ordermangementapi.azurewebsites.net/swagger`](https://ordermangementapi.azurewebsites.net/swagger)

---

## Postman Collection

- [Download the Postman Collection](https://github.com/hamza-kanaan/Exquitech-Assessment/blob/main/Order%20Management.postman_collection.json)

---

## API Endpoints

| Method | Endpoint                | Description                      |
|--------|------------------------ |----------------------------------|
| GET    | `/api/{tenantId}/Users/getAll`      | Get all users                  |
| POST   | `/api/{tenantId}/Users/register`       | Register a new user               |
| GET | `/api/{tenantId}/Orders/{id}`      | Get an order                  |
| POST    | `/api/{tenantId}/Orders/create`      | Create an order         |

_See Swagger UI for the full and up-to-date list of endpoints and their request/response schemas._

---

## Extensibility & Future Work

- **Authentication & Authorization**: Integrate ASP.NET Core Identity or JWT-based authentication.
- **Advanced Validation**: Implement more business rules, including order limits, stock checks, etc.
- **External Integrations**: Plug in with payment gateways, shipping APIs, etc.
- **Monitoring & Metrics**: Add Application Insights or Prometheus integration.
- **Deployment**: Add CI/CD pipelines and infrastructure as code (IaC) scripts.

---

## Contact

For questions, issues, or support, please [open an issue on GitHub](https://github.com/hamza-kanaan/Exquitech-Assessment/issues).

---
