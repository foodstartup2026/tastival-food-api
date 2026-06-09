# Tastival Food API

A clean architecture backend for Tastival Food using .NET 9, ASP.NET Core Web API, Entity Framework Core, PostgreSQL, CQRS, MediatR, FluentValidation, AutoMapper, JWT authentication, Serilog, Redis caching, OpenTelemetry, health checks, xUnit testing, Docker, and GitHub Actions.

## Projects

- `src/TastivalFood.Api` - ASP.NET Core Web API
- `src/TastivalFood.Application` - Business logic, CQRS, MediatR, validation, mappings
- `src/TastivalFood.Domain` - Domain entities and interfaces
- `src/TastivalFood.Infrastructure` - Persistence, Redis caching, token services
- `tests/TastivalFood.UnitTests` - Unit tests with xUnit and FluentAssertions
- `tests/TastivalFood.IntegrationTests` - Integration tests with in-memory database

## Getting Started

1. Restore packages:
   ```powershell
   dotnet restore
   ```

2. Run the API:
   ```powershell
   dotnet run --project src/TastivalFood.Api/TastivalFood.Api.csproj
   ```

3. Open Swagger at:
   ```
   https://localhost:7010/swagger
   ```

## Docker

- Build with `docker compose up --build`

## CI/CD

- GitHub Actions workflow is configured in `.github/workflows/dotnet.yml`.
