# EchoDome.Api

The API layer of the EchoDome platform. This project exposes RESTful endpoints for interacting with tournaments, users, matches, and betting features.

## Responsibilities

- Handle HTTP requests and responses
- Perform authentication and authorization (e.g., JWT)
- Map incoming DTOs to use cases
- Expose tournament and betting APIs
- Apply middleware, filters, and validation
- Serve Swagger documentation for the backend

## Key Folders

- `Controllers/` – API endpoints
- `RequestModels/` – Incoming data models (DTOs)
- `Filters/` – Global exception handling, validation filters
- `Middleware/` – Custom middlewares (e.g., logging, auth)

## Dependencies

- `EchoDome.Application`
- `EchoDome.Infrastructure`

## Getting Started

```bash
dotnet run --project EchoDome.Api