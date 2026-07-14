#  MVC APIs Controller

A RESTful Web API built with **ASP.NET Core MVC Controllers** that demonstrates modern backend development practices, including authentication with **JWT**, Entity Framework Core, SQL Server integration, and complete CRUD operations for products and categories.

---

##  Features

*  User Registration & Login using ASP.NET Core Identity
*  JWT Authentication & Authorization
*  Product Management (CRUD)
*  Category Management (CRUD)
*  Retrieve products by category
*  SQL Server integration using Entity Framework Core
*  Interactive API documentation with Swagger
*  Supports both JSON and XML responses
*  Service Layer architecture for business logic
*  RESTful API design using MVC Controllers

---

##  Technologies Used

* ASP.NET Core 8 Web API
* MVC Controllers
* C#
* Entity Framework Core
* SQL Server
* ASP.NET Core Identity
* JWT Authentication
* Swagger / OpenAPI
* LINQ
* Dependency Injection
* Git & GitHub

---

##  Project Structure

```text
MVCAPIs_Controller
│
├── Controllers/
│   ├── AccountController.cs
│   ├── ProductController.cs
│   └── CategoryController.cs
│
├── Data/
│   └── ApplicationDb.cs
│
├── DTOs/
│   ├── LoginDTO.cs
│   └── RegisterDTO.cs
│
├── Model/
│   ├── AppUser.cs
│   ├── Product.cs
│   └── Category.cs
│
├── Services/
│   └── ProductService.cs
│
├── Migrations/
│
├── Program.cs
├── appsettings.json
└── MVCAPIs_Controller.csproj
```

---

##  Authentication

The project uses **ASP.NET Core Identity** together with **JWT Bearer Authentication**.

Available authentication endpoints:

| Method | Endpoint                | Description                              |
| ------ | ----------------------- | ---------------------------------------- |
| POST   | `/api/account/register` | Register a new user                      |
| POST   | `/api/account/login`    | Authenticate user and generate JWT token |

After logging in, include the generated JWT token in the request header:

```http
Authorization: Bearer YOUR_TOKEN
```

---

##  Product Endpoints

| Method | Endpoint                       | Description              |
| ------ | ------------------------------ | ------------------------ |
| GET    | `/api/product/all`             | Get all products         |
| GET    | `/api/product/{id}`            | Get product by ID        |
| GET    | `/api/product/byCategory/{id}` | Get products by category |
| POST   | `/api/product/create`          | Create a product         |
| PUT    | `/api/product/{id}`            | Update a product         |
| DELETE | `/api/product/delete`          | Delete a product         |

---

##  Category Endpoints

| Method | Endpoint                    | Description        |
| ------ | --------------------------- | ------------------ |
| GET    | `/api/category/all`         | Get all categories |
| GET    | `/api/category/{id}`        | Get category by ID |
| POST   | `/api/category/create`      | Create category    |
| POST   | `/api/category/update/{id}` | Update category    |
| POST   | `/api/category/delete/{id}` | Delete category    |

---

##  Getting Started

### Prerequisites

* .NET 8 SDK
* SQL Server
* Visual Studio 2022

---

### Installation

Clone the repository:

```bash
git clone https://github.com/YourUsername/MVCAPIs_Controller.git
```

Navigate to the project:

```bash
cd MVCAPIs_Controller
```

Restore packages:

```bash
dotnet restore
```

Update the SQL Server connection string inside:

```text
appsettings.json
```

Apply Entity Framework migrations:

```bash
dotnet ef database update
```

Run the application:

```bash
dotnet run
```

---

##  Swagger Documentation

After starting the application, Swagger UI is available at:

```text
https://localhost:<port>/swagger
```

---

##  Project Highlights

* RESTful API development using MVC Controllers
* Layered architecture with Service Layer
* JWT-secured endpoints
* Entity Framework Core with SQL Server
* Identity-based authentication
* Dependency Injection
* JSON & XML serialization support
* Swagger/OpenAPI integration

---


##  Contributing

Contributions are welcome.

1. Fork the repository.
2. Create a feature branch.
3. Commit your changes.
4. Push to your branch.
5. Open a Pull Request.

---

##  License

This project was developed for educational purposes to demonstrate ASP.NET Core Web API development using MVC Controllers.

---

##  Author

Developed by **Moayad Madhoun**

GitHub: https://github.com/MoayadMadhoun
