# Blazing Story and Playwright
This solution consists of three distinct projects, each serving a specific purpose: 
- Building UI pages and components
- Running end-to-end tests
- Providing a smooth development playground

## Introduction
The primary project, `Blazor.Stories`, is a fork of the original [BlazingStory](https://github.com/jsakamoto/BlazingStory/) repository created by [jsakamoto](https://github.com/jsakamoto/BlazingStory/). This
project is a tailored version of [StoryBook](https://storybook.js.org/) specifically designed for Blazor applications. It empowers developers to
create and isolate UI pages and components, fostering efficient development practices.

Additionally, the repository features comprehensive end-to-end tests written using [Playwright](https://playwright.dev/), a powerful browser
automation library.

# Projects Overview
The solution is comprised of three essential projects, each serving a distinct purpose. Further details can be found in
the respective readme.md files of each project:

- ### Client: Blazor.Stories
  - Technology Stack: Blazor WebAssembly, .NET 8, Bootstrap
  - Description: This project is the core component of the solution, offering the Blazing Story toolset. It allows
  developers to create and manage UI pages and components in isolation, facilitating efficient UI development.
  
- ### Server: Blazor.Stories.Server
  - Technology Stack: .NET 8
  - Description: This project complements the client-side functionality by providing a server-side component. It 
    emulates a server environment for testing and development purposes, ensuring a comprehensive experience.
  
- ### End-to-End Tests: Stories.Playwright.Test
  - Technology Stack: .NET 8, NUnit
  - Description: This project hosts the end-to-end tests that validate the functionality of the Blazing Story solution.
    These tests are powered by [Playwright](https://playwright.dev/) and validates the effectiveness of our
    Blazor applications.

# Getting Started
To run the Blazing Story and Playwright solution, follow these steps:

1. **Run the Application**: Navigate to the project folder of either `Blazor.Stories` or `Blazor.Stories.Server` in your preferred IDE or through the command line. Using the command line, run the application using the following command:
    ```bash
    dotnet run
    ```
2. **Running Tests**: To execute tests, navigate to the `Stories.Playwright.Test` project. You can run tests both in an IDE or
   via the command line.
    ```bash
    dotnet test -- Playwright.LaunchOptions.Headless=false Playwright.LaunchOptions.SlowMo=2000
    ```

For more detailed information on each project, consult the respective readme.md files provided in their project folders.