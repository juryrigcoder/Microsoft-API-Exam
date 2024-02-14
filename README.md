# Minimal API and Razor Pages Project

This repository contains two projects: a minimal API project and a Razor Pages project, built using C# and .NET.

## Minimal API Project

The minimal API project showcases how to create a lightweight HTTP service using ASP.NET Core. It focuses on simplicity and ease of use, providing a minimalistic setup for building APIs.

### Features
- **Lightweight:** Utilizes only essential components to handle HTTP requests.
- **Routing:** Demonstrates routing setup for handling various endpoints.
- **Controllers:** Includes basic controllers to process incoming requests.
- **JSON Serialization:** Illustrates JSON serialization for data exchange.
- **Swagger Documentation:** Provides API documentation via Swagger. Accessible at [http://localhost:5197/swagger/index.html](http://localhost:5197/swagger/index.html).
- **LiteDB Integration:** Utilizes LiteDB as an embedded NoSQL database for storing data.

### Getting Started
1. Clone the repository.
2. Navigate to the `MinimalAPI` directory.
3. Run the project using `dotnet run`.
4. Access the API endpoints using a tool like Postman or cURL.

### Example Endpoint
- **GET /api/hello**: Returns a simple greeting message.

### LiteDB Usage
- The project uses LiteDB for data storage. Check the root directory for the database file (`todoApi.db`).

## Razor Pages Project

The Razor Pages project provides a web application framework built on top of ASP.NET Core, allowing for the creation of dynamic web pages with minimal overhead.

### Features
- **Razor Syntax:** Utilizes Razor syntax for creating dynamic web pages.
- **Model-View-Controller (MVC):** Implements the MVC pattern for structuring the application.
- **Routing:** Defines routes to handle incoming requests and render appropriate pages.
- **Forms Handling:** Illustrates form submission and data validation.

### Getting Started
1. Clone the repository.
2. Navigate to the `RazorPages` directory.
3. Run the project using `dotnet run`.
4. Open a web browser and navigate to the provided URL (by default, `https://localhost:5001`).

### Example Page
- **Home/Index.cshtml**: Displays a basic home page with a welcome message.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
