# EchoDome Backend

EchoDome is a modular, reusable tournament engine built in .NET 8 using Clean Architecture principles. It's designed to manage competitive tournaments, track stats, and support features like virtual betting and match history.

This backend is tournament-agnostic — it can support different games, characters, and match formats.

---

## 🧱 Architecture Overview

This solution follows **Clean Architecture** principles, separating concerns across multiple projects:

EchoDome.sln
├── EchoDome.Api/				# Web API (ASP.NET Core)
├── EchoDome.Application/		# Business logic and use cases
├── EchoDome.Domain/			# Core domain models (POCOs, enums, VOs)
├── EchoDome.Infrastructure/	# Data access, file I/O, external integrations
└── EchoDome.Tests/				# Unit and integration tests


---

## 📦 Projects

| Project                  | Description |
|--------------------------|-------------|
| `EchoDome.Api`           | REST API exposing tournament/betting endpoints |
| `EchoDome.Application`   | Core logic, use cases, interfaces (no I/O) |
| `EchoDome.Domain`        | Core domain entities, value objects, and enums |
| `EchoDome.Infrastructure`| EF Core, external services, file access |
| `EchoDome.Tests`         | Unit and integration tests for all layers |

---

## 🧪 Tech Stack

- .NET 8
- Entity Framework Core
- xUnit, Moq, FluentAssertions
- JWT Authentication (planned)
- MSSQL (SQL Server) as primary database

---

## ✅ Getting Started

```bash
# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run the API
dotnet run --project EchoDome.Api