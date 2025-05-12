# EchoDome.Tests

Unit and integration tests for EchoDome backend logic.

## Responsibilities

- Unit tests for use cases in the Application layer
- Integration tests for the API and persistence layers
- Test coverage for business rules, validators, and edge cases

## Key Folders

- `Unit/` – Pure unit tests (mocked dependencies)
- `Integration/` – Tests with real infrastructure (e.g., EF Core InMemory, TestServer)
- `Helpers/` – Common setup code, test utilities, and builders

## Dependencies

- `EchoDome.Application`
- `EchoDome.Infrastructure`
- `EchoDome.Api` (optional for integration)
- xUnit
- Moq
- FluentAssertions
- Microsoft.AspNetCore.Mvc.Testing

## Run Tests

```bash
dotnet test