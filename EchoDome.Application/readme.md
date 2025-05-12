# EchoDome.Application

This is the Application layer of the EchoDome backend. It contains the core business logic and orchestrates use cases for features such as tournaments, match handling, betting, and scoring.

This project adheres to Clean Architecture principles: it defines the business rules and interfaces but does not depend on infrastructure or delivery mechanisms (e.g., database or API).

---

## 🧠 Responsibilities

- Coordinate use cases (e.g., placing bets, starting tournaments)
- Define business rules and workflows
- Contain application-level DTOs, validators, and services
- Define interfaces for data access, external services, and domain services

---

## 📁 Structure

EchoDome.Application/
├── UseCases/ # Application services grouped by feature
│ ├── Tournaments/
│ ├── Matches/
│ └── Bets/
├── Interfaces/ # Interfaces to be implemented in Infrastructure
│ ├── Repositories/
│ └── Services/
├── DTOs/ # Data transfer objects for incoming/outgoing data
├── Validators/ # FluentValidation rules or manual checks
└── Common/ # Shared helpers, exceptions, and abstractions


---

## 🔌 Dependencies

- `EchoDome.Domain`

---

## 📌 Notes

- This layer should not reference infrastructure or delivery code (e.g., EF, Web API).
- All interfaces used by this layer (like repositories or external services) are defined here and implemented elsewhere.