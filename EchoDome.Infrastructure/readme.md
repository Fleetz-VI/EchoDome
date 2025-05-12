# EchoDome.Infrastructure

This layer provides implementations for interfaces defined in the Application layer. It is the only layer that talks directly to the database or external services.

## Responsibilities

- Implement repositories and external service access
- Provide persistence using Entity Framework Core
- Apply data mapping between entities and database models
- Register infrastructure services in DI

## Key Folders

- `Persistence/` – EF DbContext, migrations, configuration
- `Repositories/` – EF-based repo implementations
- `Services/` – Integrations (file system, external APIs)

## Dependencies

- `EchoDome.Application`
- `EchoDome.Domain`
- `Microsoft.EntityFrameworkCore`

## Notes

Infrastructure depends on Application but NOT the other way around. This ensures clean architecture principles.
