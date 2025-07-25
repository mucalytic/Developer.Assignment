# Developer.Assignment - Omnesoft Technical Task

## Overview
This solution is a full-stack application demonstrating a .NET 9 API with FastEndpoints, PostgreSQL database using Dapper, integration tests with TestContainers, and a Blazor frontend, orchestrated with .NET Aspire. It implements CRUD operations for managing products, following Clean Architecture principles for maintainability and scalability.

### Solution Structure
- **Developer.Assignment.Domain**: Core entities (e.g., Product).
- **Developer.Assignment.Contracts**: Response, request types and DTO's.
- **Developer.Assignment.Application**: Business logic and repository interfaces.
- **Developer.Assignment.Infrastructure**: Dapper/PostgreSQL implementation.
- **Developer.Assignment.Api**: FastEndpoints API for CRUD operations.
- **Developer.Assignment.Api.Tests.Integration**: Integration tests using TestContainers.
- **Developer.Assignment.Blazor**: Blazor Server app for product management UI.
- **Developer.Assignment.App.Host**: Aspire orchestration for API, database, and Blazor.
- **Developer.Assignment.Service.Defaults**: Shared configuration for health checks and service discovery.

## Prerequisites
- **.NET 9 SDK**: Install from https://dotnet.microsoft.com/download/dotnet/9.0.
- **Docker**: Required for PostgreSQL container and Aspire orchestration. Install via `sudo apt install docker-ce docker-ce-cli containerd.io docker-compose-plugin` on Linux.
- **Git**: To clone the repository.
- **IDE**: JetBrains Rider or Visual Studio Code recommended.

## Setup Instructions
1. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   cd Developer.Assignment
   ```

2. **Install .NET Aspire Workload**:
   ```bash
   dotnet workload install aspire
   ```

3. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```

4. **Ensure Docker Is Running**:
   ```bash
   sudo systemctl start docker
   ```

## Running the Application
1. **Start the Application**:
   ```bash
   dotnet run --project src/Developer.Assignment.App.Host
   ```
    - This launches the Aspire orchestrator, starting the PostgreSQL container, API, and Blazor app.
    - The PostgreSQL database (`productsdb`) is automatically created.
    - A `Products` table is initialized on API startup via a hosted service.

2. **Access the Application**:
    - **Blazor UI**: Open http://localhost:<blazor-port> (port shown in console) to view, create, edit, and delete products.
    - **API**: Use Swagger at http://localhost:<api-port>/swagger or curl (e.g., `curl http://localhost:<api-port>/products`).
    - **Aspire Dashboard**: Optional, at https://localhost:17057 (may require certificate trust, see below).

## Testing
- **Integration Tests**:
  ```bash
  dotnet test src/Developer.Assignment.Api.Tests.Integration
  ```
    - Tests use TestContainers to spin up a PostgreSQL container and validate API endpoints.

## Notes
- **Clean Architecture**: The solution separates concerns (Domain, Application, Infrastructure) for testability and maintainability.
- **Service Discovery**: Aspire enables the Blazor app to communicate with the API via injected HttpClient.
- **Certificate Issue**: If the Aspire dashboard (https://localhost:17057) shows certificate errors, trust the ASP.NET Core developer certificate:
  ```bash
  dotnet dev-certs https
  dotnet dev-certs https --export-path ~/.aspnet/https/aspnetapp.pfx -p mypassword
  openssl pkcs12 -in ~/.aspnet/https/aspnetapp.pfx -clcerts -nokeys -out ~/.aspnet/https/aspnetapp.crt -passin pass:mypassword
  ```
  Import `aspnetapp.crt` into Firefox (Settings > Privacy & Security > Certificates > Authorities > Import).
