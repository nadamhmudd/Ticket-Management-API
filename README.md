# [Ticket Management API](https://ticketdotnetapi.azurewebsites.net/swagger/index.html)
API for Manage events, ticket sales etc.

# Application Architecture
### REST API 
- Built using ASP.NET Core (.net 6)
- Followed Clean architecture principles 
- Data access(SQL Server) using EF Core
### Class libraries
- .NET Standard

#
### Implementing Repository Pattern to Access Database.
### Implementing CQRS and Mediator Patterns (Using MediatR).
### Mapping Between Objects (Using AutoMapper). 
### Adding Validation Using Fluent Validation.
### Handling cross-cutting concerns : 
    - Handling Exceptions 
    - logging with serilog 
    - JWT Authenticating along with ASP.NET Identity.
### Sending a Mail using SMTP.
### Returning a CSV File.
### Exposing the API functionality using Swagger.
### Generating client code(.NET Core and TypeScript) to use the API using NSwag.
