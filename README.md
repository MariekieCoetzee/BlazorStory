# Blazing Story and Playwright
Inspired by [jsakamoto](https://github.com/jsakamoto/BlazingStory/)'s BlazingStory.  It is  a clone of [StoryBook](https://storybook.js.org/) but focused on Blazor.
It allows us to build UI pages and components in isolation.

This repo includes QuickGrid component with all the features it offers. 

The repo includes end-to-end tests written in [Playwright](https://playwright.dev/).

# Playground
There are 3 projects
- Client : Blazor.Stories (BlazorWebAssembly, .Net8)
- Server : Blazor.Stories.Server (.Net8, Fake server)
- E2E Tests : Stories.Playwright.Test (.Net8, NUnit) 

# Running the app
Navigate to `Blazor.Stories` or `Blazor.Stories.Server` and run the application either IDE or CLI
```bash
dotnet run
```
## Test
The test can be run in IDE or via CLI.  It will startup the server in memory and run the tests.

In CLI navigate to `Stories.Playwright.Test`.  

Running with headless set to false (load the browser and simulate user interaction): 
```bash
dotnet test -- Playwright.LaunchOptions.Headless=false
```