# Tywynh

A layered .NET 8 Web API for managing stories, following clean architecture principles.

## Features

- **Post a Story**: Submit a new story with text and category.
- **Get Stories**: Retrieve all stories.
- **CQRS Pattern**: Uses commands and queries with a custom mediator.
- **Entity Framework Core**: Data access with repository pattern.
- **Extensible**: Easily add new features and endpoints.

## Project Structure

- `Tywynh.API` – ASP.NET Core Web API (endpoints, middleware)
- `Tywynh.Domain` – Domain models and interfaces
- `Tywynh.Infrastracture` – Data access, repositories, EF Core context
- `Tywynh.Features` – Application logic (commands, queries, handlers, mediator)

## Endpoints

### Stories
| Method | Route                    | Description                    |
|--------|--------------------------|--------------------------------|
| POST   | `/api/stories`           | Create a new story             |
| GET    | `/api/stories`           | Get all stories                |
| GET    | `/api/stories/random`    | Get random stories             |
| POST   | `/api/stories/{id}/heart`| Add a heart to a story         |

### Categories
| Method | Route              | Description           |
|--------|-------------------|----------------------|
| POST   | `/api/categories`  | Create a new category |
| GET    | `/api/categories`  | Get all categories    |

### Thoughts
| Method | Route         | Description                    |
|--------|---------------|--------------------------------|
| GET    | `/api/thoughts`| Get uplifting thoughts (with query parameter) |

### Logs
| Method | Route      | Description           |
|--------|------------|----------------------|
| GET    | `/api/logs`| Get all request logs  |

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- PostgreSQL, SQLite, or another supported database (see `appsettings.json`)

### Setup

1. **Clone the repository**


2. **Configure the database**
   - Update the connection string in `Tywynh.API/appsettings.json`.

3. **Apply migrations**


4. **Run the API**


5. **Explore the API**
   - Swagger UI available at `https://localhost:5001/swagger` (in development).

## Contributing

Pull requests are welcome! For major changes, please open an issue first.

## License

MIT
