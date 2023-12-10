# Template .NET Core

This template was built based on best practices and concepts that bring efficiency when coding and maintaining it. The goal was to make it easy to implement cohesive code and difficult to implement coupled codes.

The purpose was to develop a template that easily accepts **Change**, so that if it occurs, it does not require changes in numerous other parts of the system that are not part of the change context. **Robustness** is essential in case a change is made to prevent unexpected breaks in other parts of the system. Lastly, **Mobility** ensures easy reuse of its features/layers, as the software is always evolving, and this point is crucial for the ease of its progression.

The main architectural reference is based on the proposal by Uncle Bob in his book Clean Architecture. You can follow the link to a post with a brief introduction: [Clean Architecture](https://imasters.com.br/back-end/introducao-clean-architecture).

It was designed for a generic resolution. If your project requires a specific structure that the template does not provide, feel free to contact me.


# Overview

It is a simple car wash system where a customer can be registered along with their vehicles, and car wash orders can be created for them. 
It features an event-driven pattern so that when an order is created, it can send a message to a message broker, and when the order is completed, it's possible to send an SMS to the customer.

## Stack Technical

- [ASP.NET Core 7](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [Entity Framework Core 7](https://docs.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [Swagger](https://swagger.io/)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://fluentvalidation.net/)
- [XUnit](https://xunit.net/), [FluentAssertions](https://fluentassertions.com/), [AutoFixture](https://autofixture.github.io/) and [Moq](https://github.com/moq)

### Database Configuration

The template is configured to use an _inMemory_ database by default. This ensures that all users can run the solution without having to configure the database.

If you want to use the SQL Server provider, which is the choice of this template, just change the app configuration in the project by disabling the _inMemory_ in **appsettings.json**:

```json
  "UseInMemoryDatabase": false,
```

Add your database connection string to the **DefaultConnection** in the **appsettings.json** file.

### Migrations

Use the `dotnet-ef` command for migrations; add the following tags to the command (the values assume that you are executing from the root of the repository).

* `--project src/Architecture.Template.Infrastructure` (optional if you are on the path)
* `--startup-project src/Architecture.Template.WebApi`
* `--output-dir Migrations`

For example, to add a new migration on the root path:

 `dotnet ef migrations add "InitialMigration" --project src\Architecture.Template.Infrastructure --startup-project src\WebUI --output-dir Migrations`

## Patterns and principples
All patterns and principles had their importance in building a template that is easy to maintain and implement new features, segregating responsibilities, leaving the project with high cohesion and low coupling.

* **SOLID**: It is the most important of all; it is directly related to object-oriented programming. It helps us segregate our project responsibilities, create new cohesive features, extend them when necessary, define proper inheritances between objects, set specific contracts (interfaces) for each class, and decouple between layers and objects. This is undoubtedly the biggest benefactor of our project. To understand more about its violations and solutions, simply download this repository: [SOLID](https://github.com/hcostapuc/Samples.SOLID)

* **CQRS**: (_Command Query Responsibility Segregation_) It is the pattern that helps us maintain cohesion from the beginning to the end of the project, preserving the ease and safety of creating new features without affecting other processes. This helps us stay closer to the clean architecture proposed by Uncle Bob in his book, keeping the user cases well-separated from the first layer to the last. It essentially separates information retrieval (queries) from modification and insertion (commands). Here is the official Microsoft documentation discussing the pattern: [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)

* **Mediator**: It is a pattern that suggests you should cease all direct communication between components that you want to make independent of each other. Instead, these components should collaborate indirectly by calling a special mediator object that redirects calls to the appropriate components. It aids in communication between the presentation and application layers, mediating communication between the layers. Follow this article for more details on the pattern: [Mediator](https://refactoring.guru/design-patterns/mediator)

* **KISS**: (_Keep It Simple, Stupid_) This is a very important pattern as it brings simplicity to our day-to-day work. Complexity should only exist where necessary and nothing more. This goes beyond the code itself, encompassing our analysis and the entire software development process. Solving problems in a simple way brings us efficiency and a quick understanding of that context by other professionals on the team. Follow an article that explains its purpose and guidelines: [KISS](https://www.interaction-design.org/literature/article/kiss-keep-it-simple-stupid-a-design-principle)

* **DRY**: (_Don't Repeat Yourself_) It is something that is already intrinsic, and we commonly do it in our daily work. It is here to reinforce this practice. Its purpose is basically to avoid code repetition in your project, abstracting, extending, and unifying some of these points. This will depend directly on the context in which it is found and how the unification will take place. Follow an article that provides more details about the pattern: [DRY](https://medium.com/@rafaelsouzaim/n%C3%A3o-se-repita-dry-dont-repeat-yourself-40da33289bcf)

* **AAA**: (_Arrange Act Assert_) This pattern was created to support the creation of our unit tests. Its benefit lies in the organization of test contexts, separating them into Arrange: everything I need to instantiate to create my test, Act: the call to the method in question that I will test, passing the objects created in Arrange, and Assert: where everything needed to validate if that return was indeed as expected should be placed. They can be separated by comments, and this is not a bad practice because, unlike the code itself, unit tests have peculiarities that should be followed, such as making them as explicit as possible. Follow an article that provides more details about the pattern: [AAA](https://medium.com/@pjbgf/title-testing-code-ocd-and-the-aaa-pattern-df453975ab80)

## Application layers

### Domain

This layer will contain all entities, enumerations, exceptions, interfaces, types, and logic specific to the domain layer.

### Application

This layer contains all the application logic. It is the entry point for the Core. It is dependent on the domain layer but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by external layers. For example, if the application needs to access a notification service, a new interface will be added to the application, and an implementation will be created in the infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, databases, integrations, SMTP, and so on. These classes should be based on interfaces defined in the application layer.

### Presentation

This layer is where you will expose your application, commonly as a web application, typically an API. This layer depends on the Application and Infrastructure layers; however, the dependency on infrastructure is only for supporting dependency injection. Therefore, only Startup.cs should reference the infrastructure.

## Suporte

If you have any questions about the template, feel free to contact me via email:  hcostapuc@gmail.com