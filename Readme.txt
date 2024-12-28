.Net Core web APIs
Clean Architecture Pattern with CQRS, MediatR

Dependencies Between Layers
The dependencies flow as follows:
 - Domain: No dependencies on any other layer.
 - Application: Depends on the Domain layer.
 - Infrastructure: Depends on Application and Domain layers (implements interfaces defined in them).
 - Presentation: Depends on Application (via MediatR or service injection).

Domain Layer
  → The project that contains the domain layer, including the entities, value objects, and domain services
Application Layer
  → The project that contains the application layer and implements the application services, DTOs (data transfer objects), MediatR and mappers. It should reference the Domain project.
Infrastructure Layer
  → The project contains the infrastructure layer, including the implementation of data access,db, Repositories, logging, email, and other communication mechanisms. It should reference the Application project.
Presentation Layer
  → The main project contains the presentation layer and implements the ASP.NET Core web API. It should reference the Application and Infrastructure projects.

