# BookStore E-Commerce API

A robust and scalable e-commerce API built with .NET 9, implementing modern software architecture principles and best practices.

## 🏗 Architecture

This project follows a clean, maintainable, and scalable N-Tier Architecture:

```
BookStore.API (Presentation Layer)
    ↓
BookStore.Business (Business Layer)
    ↓
BookStore.Data (Data Access Layer)
```

### Key Architectural Features

- **Clean Architecture** principles
- **Domain-Driven Design (DDD)** approach
- **Repository Pattern** for data access abstraction
- **SOLID Principles** implementation
- **Dependency Injection** for loose coupling

## 🛠 Technologies & Tools

- **.NET 9**
- **Entity Framework Core 9.0**
- **SQL Server**
- **AutoMapper** for object mapping
- **JWT Authentication**
- **Identity Framework** for user management
- **Swagger/OpenAPI** for API documentation
- **CORS** configuration for cross-origin requests

## 🏢 Project Structure

### BookStore.API
- RESTful API endpoints
- JWT authentication
- Swagger documentation
- CORS configuration

### BookStore.Business

- Business logic implementation
- DTOs (Data Transfer Objects)
- AutoMapper profiles
- Service implementations
- Business rules and validations

### BookStore.Data

- Entity Framework Core configurations
- Entity models
- Repository implementations
- Database context
- Migrations

## 🔑 Key Features

- User authentication and authorization
- Book and Category management
- Shopping cart functionality
- Order processing
- Role-based access control

## 🎯 Best Practices Implemented

- Clean Code principles
- SOLID principles
- DRY (Don't Repeat Yourself)
- Interface Segregation
- Dependency Inversion
- Repository Pattern
- DTO Pattern