## 🛠️ Technologies and Tools Used

- **Runtime/Language:** .NET (C#)
- **Web Framework:** ASP.NET Core Web API
- **Data Access (ORM):** Entity Framework Core (EF Core)
- **Database:** Microsoft SQL Server
- **Security:** BCrypt.Net-Next (for password hashing)
- **Documentation:** Swagger / OpenAPI

## 🗄️ Database Modeling

The API manages the user entity mapped directly to the `users` table in SQL Server, structured with the following fields:

| Field | Data Type | Constraints / Details |
| :--- | :--- | :--- |
| `id` | Guid / UniqueIdentifier | Primary Key (PK) automatically generated |
| `name` | String / NVARCHAR | Full name of the user |
| `email` | String / NVARCHAR | Unique in the system (Unique Index) |
| `password` | String / NVARCHAR | Secure hash of the encrypted password |
| `role` | String / NVARCHAR | User access profile (e.g., `user`, `admin`) |
| `created_at` | DateTime | Timestamp of record creation (UTC) |

## 📐 Design Patterns and Architecture

The backend was structured following the principles of **Separation of Concerns** and well-established conventions of the .NET community:

- **Controller-Service Pattern:** Clear split between the HTTP transport/routing layer (`Controllers`) and the layer that centralizes business rules and validations (`Services`).
- **Data Transfer Objects (DTOs):** Use of specific payloads for data input with robust validations via *Data Annotations* (preventing direct exposure of the database model).
- **Dependency Injection:** Utilization of ASP.NET Core's native container to manage the lifecycle of the database context and services.
- **Security by Default:** The `password` field strictly stores the secure hash generated via BCrypt. Furthermore, response endpoints omit the password hash for privacy and data protection purposes.

## 🚀 Current Features

- **User Registration:** Email format validation, database duplication check, and password encryption.
- **User Listing:** Secure endpoint for querying registered profiles.
- **Interactive Documentation:** Integrated Swagger UI for quick endpoint testing in development environments.
