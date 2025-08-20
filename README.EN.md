# Kayra Export - Task 1 - ProductApi

[Click here for the Turkish version of this document.](./README.md)

---

This project is a RESTful API developed for the technical assessment of the Kayra Export Backend Developer position. The project aims to showcase fundamental backend development principles, modern tools in the .NET ecosystem, and clean architecture approaches.

### Project Description

This API manages basic CRUD (Create, Read, Update, Delete) operations for products. It is developed with a layered structure following Clean Architecture principles, ensuring a clear separation of concerns.

### Core Features

-   **Layered Architecture:** Consists of 4 main layers: `Domain`, `Application`, `Infrastructure`, and `Api`.
-   **SOLID Principles:** Principles such as Single Responsibility and Dependency Inversion are applied throughout the project.
-   **Repository & Unit of Work Patterns:** Data access logic is fully abstracted from the business layer, and transaction management is centralized.
-   **Asynchronous Programming:** All I/O operations are performed asynchronously using `async/await` to improve performance and scalability.
-   **Strongly-Typed Configuration:** Settings like the database connection are managed using the Options Pattern.
-   **Global Error Handling:** All unexpected errors are caught by a central `Middleware`, which returns a standardized, user-friendly response.
-   **Rich API Documentation:** The Swagger UI is enriched with XML comments that describe both the endpoints and DTO schemas.

### API Endpoints

This API provides the following core RESTful operations for product management. For detailed usage, parameters, and response models for all endpoints, please refer to the **Swagger UI** on the running application.

| Method | Endpoint            | Description                |
| :----- | :------------------ | :------------------------- |
| `GET`  | `/api/products`     | Retrieves all products.    |
| `GET`  | `/api/products/{id}`| Retrieves a single product.|
| `POST` | `/api/products`     | Creates a new product.     |
| `PUT`  | `/api/products/{id}`| Updates an existing product.|
| `DELETE`| `/api/products/{id}`| Deletes a product.         |

### Technologies Used

-   .NET 9
-   ASP.NET Core Web API
-   Entity Framework Core
-   PostgreSQL
-   AutoMapper
-   FluentValidation
-   Swagger

### Setup and Running Instructions

Follow these steps to get the project up and running on your local machine.

#### Prerequisites

-   .NET SDK (Compatible with the version used in the project)
-   PostgreSQL database server
-   A database management tool (optional)

#### Installation

1.  **Clone the Repository:**
    ```sh
    git clone https://github.com/KadirAkyaman/KayraExport.ProductApi
    ```

2.  **Configure the Database Connection:**
    -   Open the `src/KayraExport.Api/appsettings.json` file.
    -   In the `DatabaseSettings` section, find the `DefaultConnection` string and replace the `User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;` placeholders with your own PostgreSQL credentials.

    ```json
    "DatabaseSettings": {
      "DefaultConnection": "Server=127.0.0.1;Port=5432;Database=ProductAPI;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
    }
    ```

3.  **Apply Database Migrations:**
    -   Open a terminal in the project's root directory (where the `.sln` file is located).
    -   Run the following command to create the database and the `Products` table:
    ```sh
    dotnet ef database update --startup-project src/KayraExport.Api
    ```

4.  **Run the Application:**
    -   In the same terminal, run the following command to start the application:
    ```sh
    dotnet run --project src/KayraExport.Api
    ```

5.  **Access the API:**
    -   The application will start running on the URLs specified in the terminal. You can check the `applicationUrl` property in the `src/KayraExport.Api/Properties/launchSettings.json` file to see which ports are being used (e.g., `https://localhost:5020`).
    -   To test the API and view the documentation, navigate to the HTTPS address in your browser and append `/swagger` to it (e.g., `https://localhost:7001/swagger`).

---