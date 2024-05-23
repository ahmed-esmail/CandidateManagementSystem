# CandidateManagementSystem

## Description

A .NET web application providing a REST API to manage job candidate information. The API supports creating and updating candidate profiles based on their email.

## API Testing

We use HTTP files for testing our API endpoints. These files are supported by Visual Studio Code with the REST Client extension.

## Technologies
- ASP.NET Core 8
- Entity Framework Core 8
- Angular 15 or React 18
- MediatR
- AutoMapper
- FluentValidation
- NUnit, FluentAssertions, Moq & Respawn

### How to Use

1. Open the [Web.http](src%2FWeb%2FWeb.http) file in VS .
2. You'll see a "Send Request" link above each HTTP request. Click this link to send the request.
3. The response will be displayed in a separate pane in VS .
   The `Web.http` file contains several HTTP requests for testing our API. Here's a brief overview:
#### File Sturcture
- Variables: The file starts with some variable declarations. These variables store values that are used in multiple places in the file.
- POST Users Login: This is a POST request to the `/api/Users/Login` endpoint. It uses the `@Email` and `@Password` variables to log in a user.
- POST Candidates: This is another POST request, this time to the `/api/Candidates` endpoint. It's used to create or update a candidate.

For more information on HTTP files, visit [https://aka.ms/vs/httpfile](https://aka.ms/vs/httpfile). file contains several HTTP requests for testing our API. Here's a brief overview:

- Variables: The file starts with some variable declarations. These variables store values that are used in multiple places in the file.
- POST Users Login: This is a POST request to the `/api/Users/Login` endpoint. It uses the `@Email` and `@Password` variables to log in a user.
- POST Candidates: This is another POST request, this time to the `/api/Candidates` endpoint. It's used to create or update a candidate.

For more information on HTTP files, visit [https://aka.ms/vs/httpfile](https://aka.ms/vs/httpfile).

## Assumptions

1. **Separation of Concerns**:

   - The application is divided into multiple layers, each with a specific responsibility. These layers include:
     - **Domain**: Contains domain entities, interfaces, and business logic.
     - **Application**: Contains application logic, such as use cases and service interfaces.
     - **Infrastructure**: Contains implementations of interfaces, external service integrations, and data access logic.
     - **Web**: Contains the API layer.

2. **Dependency Injection**:

   - The project uses Dependency Injection (DI) extensively to manage dependencies across different layers. This is configured in the `DependencyInjection.cs` file in each layer.

3. **Domain-Driven Design (DDD)**:

   - The Core and Application layers follow DDD principles, emphasizing the use of domain entities, value objects, and aggregates.

4. **Repository Pattern**:

   - Data access is abstracted through repository interfaces in the Core layer and their implementations in the Infrastructure layer.

5. **CQRS (Command Query Responsibility Segregation)**:

   - The application logic is divided into Commands (write operations) and Queries (read operations), each handled by their respective handlers.

6. **Event-Driven Architecture**:

   - The architecture might use domain events to propagate changes and trigger side effects across different parts of the application.

7. **Testability**:

   - The architecture is designed to be highly testable, with each layer being independently testable through unit tests and integration tests.

8. **Scalability and Maintainability**:
   - The architecture is designed to be scalable and maintainable, allowing for easy addition of new features and modifications without impacting existing functionality.
9. **Security**:
   - The API is secured using the `Microsoft.AspNetCore.Identity.EntityFrameworkCore` package, which provides a fast and testable way to implement authentication and authorization.

## Total Time Spent

##### **Seven hours**

## List of ways for improvement
- Add Complete CI/CD pipeline
- 
## Build

Run `dotnet build -tl` to build the solution.

## Run

To run the web application:

```bash
cd .\src\Web\
dotnet watch run
```

Navigate to https://localhost:5001. The application will automatically reload if you change any of the source files.

## Code Styles & Formatting

The template includes [EditorConfig](https://editorconfig.org/) support to help maintain consistent coding styles for multiple developers working on the same project across various editors and IDEs. The **.editorconfig** file defines the coding styles applicable to this solution.

## Code Scaffolding

The template includes support to scaffold new commands and queries.

Start in the `.\src\Application\` folder.

Create a new command:

```
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

Create a new query:

```
dotnet new ca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

If you encounter the error _"No templates or subcommands found matching: 'ca-usecase'."_, install the template and try again:

```bash
dotnet new install Clean.Architecture.Solution.Template::8.0.5
```

## Test

The solution contains unit, integration, and functional tests.

To run the tests:

```bash
dotnet test
```
