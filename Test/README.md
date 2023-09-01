# Stories.Playwright.Test

This project is inspired by the insights shared during one of 
[Microsoft's community stand-ups](https://www.youtube.com/watch?v=lJa3YlUliEs).  During the session Mackinnon Buck,
Microsoft developer, shared a [repository](https://github.com/MackinnonBuck/blazor-playwright-example) 
that forms the basis of this project.  

---
Note : This project caters specifically to Blazor WebAssembly (Wasm) projects.

---

# Introduction to Playwright
This project hosts the end-to-end tests that validate the functionality of the Blazing Story solution.
These tests are powered by [Playwright](https://playwright.dev/) and validates the effectiveness of our
Blazor applications.

# TechStack

The client project is developed with the following tech & libraries :
-.NET 8, 
- Bl
- NUnit
- Microsoft.Playwright.NUnit
- Microsoft.AspNetCore.Mvc.Testing

## Infrastructure
This projects includes a class, in the Infrastructure folder, that references
[WebApplicationFactory](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactory-1?view=aspnetcore-8.0) from the
[Microsoft.AspNetCore.Mvc.Testing](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-8.0) package.
This class creates a TestServer for integration tests.

# Getting Started

To run the tests, either in your integrated development environment (IDE) or via the command line, use the following
command:
`Headless=false` : This option opens up the browser and simulates user interactions, providing valuable insights.
`SlowMo=2000` : Slowing down the process ensures that you can easily follow the simulation.
```bash
dotnet test -- Playwright.LaunchOptions.Headless=false Playwright.LaunchOptions.SlowMo=2000
```