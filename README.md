# Project Overview

This project is a **microservices-based e-commerce backend** built using **.NET**, following **Clean Architecture**, **CQRS**, and **Domain-Driven Design (DDD)** principles. The solution is designed with a strong focus on maintainability, scalability, and separation of concerns.

The system currently consists of multiple independent services, including **Basket Service**, **Product Service**, and **Order Service**, alongside a shared **Core** library that contains common abstractions, middleware, behaviors, infrastructure components, and reusable utilities used across all services.

Communication between microservices is implemented using **gRPC** for high-performance synchronous calls, while the messaging infrastructure is prepared using **RabbitMQ** and **MassTransit** for asynchronous communication and event-driven architecture. Although the messaging infrastructure is fully configured, domain integration events are intentionally not published in this assignment.

The application follows the **CQRS** pattern using **MediatR**, where commands, queries, and domain events are handled through a clean and extensible pipeline.

---

# Challenges

The primary challenge of this project was not the implementation itself, but designing a clean architecture based on an incomplete and sometimes ambiguous requirements document.

A significant amount of time was dedicated to:

* Analyzing business requirements
* Designing service boundaries
* Defining domain models
* Choosing appropriate architectural patterns
* Structuring reusable infrastructure for future microservices

Rather than focusing only on delivering the requested features, the goal was to build a production-ready architecture that can easily evolve as new services and business requirements are introduced.

---

# Implemented Features

## Architecture

* Designed the solution based on **Clean Architecture**
* Implemented **CQRS** with complete separation of Commands and Queries
* Designed and implemented custom **Command Dispatcher** and **Query Dispatcher**
* Implemented **ICommand**, **IQuery**, **ICommandHandler**, and **IQueryHandler**
* Created a shared **Core** project containing reusable abstractions and infrastructure components
* Organized the solution into independent microservices
* Configured dependency injection using marker interfaces
* Standardized project structure across all services

---

## Microservices

* Implemented independent **Basket Service**
* Implemented **Product Service**
* Implemented **Order Service**
* Established synchronous service-to-service communication using **gRPC**
* Defined shared gRPC contracts using Protocol Buffers
* Configured gRPC clients and servers for inter-service communication
* Prepared the solution for future service expansion

---

## Domain-Driven Design

* Designed rich domain entities such as **Basket** and **BasketItem**
* Encapsulated business rules inside domain entities
* Implemented **Domain Events**
* Implemented automatic domain event dispatching after successful transactions
* Applied aggregate boundaries and domain encapsulation principles

---

## Basket Functionality

* Create or retrieve customer baskets
* Add products to basket
* Update item quantities
* Remove items from basket
* Clear basket
* Basket expiration management
* Scheduled expiration processing

---

## Validation & Error Handling

* Implemented **ValidationBehavior** using MediatR Pipeline
* Used **FluentValidation** for command validation
* Implemented centralized exception handling middleware
* Designed custom **Domain Exceptions**
* Implemented **ServiceResult** and **ServiceResult<T>**
* Standardized API responses using **ToApiResult**

---

## Persistence

* Implemented **Repository Pattern**
* Implemented **Unit of Work**
* Created specialized repositories
* Implemented persistence using **Entity Framework Core**
* Configured entities using **Fluent API**
* Created database migrations
* Optimized read operations using **AsNoTracking**
* Applied asynchronous programming with **CancellationToken**

---

## Pipeline & Cross-Cutting Concerns

* Implemented custom **TransactionBehavior**
* Automatic transaction management
* Commit/Rollback handling
* Automatic Domain Event dispatching
* Centralized dependency registration
* Shared middleware and reusable infrastructure components

---

## Caching & Messaging

* Configured **Redis**
* Implemented basket caching
* Cache invalidation after updates
* Configured **RabbitMQ**
* Configured **MassTransit**
* Implemented background services for scheduled tasks
* Prepared infrastructure for asynchronous event-driven communication

---

## API

* Implemented REST APIs for Basket operations
* Standardized API responses
* Used **Primary Constructors**
* Applied **Expression-bodied Members** where appropriate
* Fully asynchronous implementation across Application and Infrastructure layers

