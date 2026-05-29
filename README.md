A production‑ready .NET 8 Web API for managing customer and order data, built using Clean Architecture, Entity Framework Core, SQL Server, and structured validation.
This project demonstrates real‑world backend development practices including layered design, DTO mapping, validation, error handling, and RESTful API standards.

🚀 Features
Full CRUD operations for Customers and Orders

Built with .NET 8 Web API

Clean Architecture (Controllers → Services → Repositories → Database)

Entity Framework Core with SQL Server

FluentValidation for request validation

Global exception handling + structured error responses

DTOs & AutoMapper for clean data transfer

Dependency Injection throughout the solution

Swagger/OpenAPI documentation enabled

Asynchronous programming for all database operations

Presentation Layer (Controllers)
        ↓
Application Layer (Services, DTOs, Validation)
        ↓
Infrastructure Layer (Repositories, EF Core, SQL Server)
        ↓
Database (SQL Server)
