# Exquitech-Assessment
Exquitech's Assessment

# Order Management Solution

A RESTful API for managing orders, built with ASP.NET Core (.NET 9, C# 13).

## Table of Contents

- [Setup & Run Instructions](#setup--run-instructions)
- [Architectural Decisions](#architectural-decisions)
- [Assumptions](#assumptions)
- [Deployed API (Azure App Service)](#deployed-api-azure-app-service)
- [Postman Collection](#postman-collection)
- [API Endpoints](#api-endpoints)

---

## Setup & Run Instructions

1. **Prerequisites:**
   - [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
   - (Optional) [SQLite](https://www.sqlite.org/download.html) if you want to inspect the database file directly
2. **Clone the repository:**
   - git clone <your-repo-url> cd <repo-folder>
3. **Restore dependencies:**
   - dotnet restore
4. **Build the solution**
5. The API will be available at `https://localhost:7142`.
6. **Swagger UI**
   - Navigate to `https://localhost:7142/swagger` for API documentation and testing.
7. **Run Tests**
   - dotnet test

---

## Architectural Decisions

- **Clean Architecture**: The solution is split into Domain, Application, Infrastructure, and API layers for separation of concerns and testability.
- **Dependency Injection:** Services are injected via constructor for testability and maintainability.
- **DTO Usage:** Data Transfer Objects (DTOs) are used to decouple API contracts from domain models.
- **Async/Await:** All service calls are asynchronous for scalability.
- **RESTful Endpoints:** Follows REST conventions for resource management.
- **Entity Framework Core**: Used for data access with SQLite as the default provider.
- **Serilog**: For structured logging.
- **FluentValidation**: For validating DTOs and input models.
- **AutoMapper**: For mapping between domain entities and DTOs.
- **Swagger/OpenAPI**: For API documentation and testing.
- **Custom Middleware**: Exception handling and tenant resolution are handled via middleware.

---

## Assumptions

- User authentication/authorization is not implemented in this version.
- The API expects valid data; input validation is minimal.
- The data store is abstracted (SQLite for demonstration).
- The database is automatically migrated on application startup.
- The API is multi-tenant, with tenant resolution handled by middleware.
- User registration checks for existing users by email.
- Logging is required for both successful and failed attempts.

---

## Deployed API (Azure App Service)

- **Base URL:** `https://ordermangementapi.azurewebsites.net`
- Navigate to `https://ordermangementapi.azurewebsites.net/swagger` for API documentation and testing.

---

## Postman Collection

- [Download the Postman Collection](<link-to-your-postman-collection>)

_Replace with your actual Postman collection link._

---

## API Endpoints

| Method | Endpoint              | Description         |
|--------|----------------------|---------------------|
| GET    | `/api/orders/{id}`   | Get order by ID     |
| POST   | `/api/orders/add`    | Create a new order  |

---

## Contact

For questions or support, please open an issue on GitHub.
