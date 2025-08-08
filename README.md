# Exquitech-Assessment
Exquitech's Assessment

# Order Management API

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

1. **Clone the repository:**
2. **Restore dependencies:**
3. **Build the solution:**
4. **Run the API:**
5. The API will be available at `https://localhost:7142` (or as configured).

---

## Architectural Decisions

- **Clean Architecture:** The solution is structured into API, Application, and Domain layers to enforce separation of concerns.
- **Dependency Injection:** Services are injected via constructor for testability and maintainability.
- **DTO Usage:** Data Transfer Objects (DTOs) are used to decouple API contracts from domain models.
- **Async/Await:** All service calls are asynchronous for scalability.
- **RESTful Endpoints:** Follows REST conventions for resource management.

---

## Assumptions

- User authentication/authorization is not implemented in this version.
- The API expects valid data; input validation is minimal.
- The data store is abstracted (SQLite for demonstration).
- The API is intended for demonstration and may not be production-ready.

---

## Deployed API (Azure App Service)

- **Base URL:** `https://ordermangementapi.azurewebsites.net`

_Replace with your actual Azure App Service URL._

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
