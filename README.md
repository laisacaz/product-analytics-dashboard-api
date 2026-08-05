# Product Analytics Dashboard API

Backend API for a Product Analytics Dashboard built with ASP.NET Core.

This project is being developed following Clean Architecture principles, focusing on scalability, maintainability and separation of responsibilities.

## Technologies

- ASP.NET Core Web API
- C#
- Clean Architecture
- Entity Framework Core
- JWT Authentication
- Google OAuth Authentication
- PostgreSQL

## Architecture

The solution is organized into the following layers:

src
├── Domain
├── Application
├── Infrastructure
└── WebApi

### Domain
Contains the core business entities and rules.

### Application
Contains application use cases, services, DTOs and interfaces.

### Infrastructure
Contains external integrations, database access and authentication implementations.

### WebApi
Contains controllers, HTTP configuration and API endpoints.

## License

This project is for learning and portfolio purposes.
