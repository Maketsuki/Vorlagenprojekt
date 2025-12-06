# Vorlagenprojekt

A Clean Architecture template project for .NET applications, featuring a Blazor WebAssembly frontend and a PostgreSQL backend. Designed as a lightweight seed for future projects.

## Technologies

This project is built using the following technologies:

- **.NET**: 10.0
- **Language**: C# 14 (implied by .NET 10)
- **Database**: PostgreSQL 16
- **Frontend**: Blazor WebAssembly
- **ORM**: Entity Framework Core
- **Containerization**: Docker & Docker Compose

## Architecture

The solution follows the Clean Architecture principles:

- **Vorlagen.Domain**: Enterprise logic and entities (No dependencies).
- **Vorlagen.Application**: Business logic and interfaces (Depends on Domain).
- **Vorlagen.Infrastructure**: External concerns like Database, File System (Depends on Application).
- **Vorlagen.Api**: REST API entry point (Depends on Application & Infrastructure).
- **Vorlagen.Blazor**: Frontend client (Depends on Application DTOs).

## Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Local Development

1.  **Start the Database**:
    Use Docker Compose to spin up the PostgreSQL database.
    ```bash
    cd docker
    docker-compose up -d db
    ```

2.  **Apply Migrations**:
    Navigate to the API directory and update the database.
    ```bash
    cd src/Vorlagen.Api
    dotnet ef database update
    ```

3.  **Run the API**:
    ```bash
    dotnet run
    ```
    The API will be available at `http://localhost:5000` (or the port configured in launchSettings.json).

4.  **Run the Blazor App**:
    Open a new terminal and navigate to the Blazor project.
    ```bash
    cd src/Vorlagen.Blazor
    dotnet run
    ```
    The application will launch in your default browser.

## Build and Deploy

### Docker

The project includes a `Dockerfile` for the API and a `docker-compose.yml` for orchestrating the full stack (API + Database).

**Build and Run everything:**

```bash
cd docker
docker-compose up --build
```

This will:
1.  Build the API image.
2.  Start the PostgreSQL container.
3.  Start the API container.

### Manual Build

To build the solution manually:

```bash
dotnet build
```

To publish the API for deployment:

```bash
dotnet publish src/Vorlagen.Api -c Release -o ./publish/api
```

To publish the Blazor client:

```bash
dotnet publish src/Vorlagen.Blazor -c Release -o ./publish/blazor
```