using Microsoft.Extensions.Configuration;

namespace BlazorSSR.Stories.Tests;

[Collection(PlaywrightFixture.PlaywrightCollection)]
public class UnitTest1
{
    private readonly PlaywrightFixture _playwrightFixture;

    public UnitTest1(PlaywrightFixture playwrightFixture)
    {
        _playwrightFixture = playwrightFixture;
    }

    [Fact]
    public async Task Test1()
    {
        var url = "https://localhost:7297/?path=/docs/example-button--docs";

        using var hostFactory = new WebTestingHostFactory<AssemblyClassLocator>();
        hostFactory
            // Override host configuration to mock stuff if required.
            .WithWebHostBuilder(
                builder =>
                {
                    // Setup the url to use.
                    builder.UseUrls(url);
                    // Replace or add services if needed.
                    builder.ConfigureServices(
                            services =>
                            {
                                // services.AddTransient<....>();
                            }
                        )
                        // Replace or add configuration if needed.
                        .ConfigureAppConfiguration(
                            (app, conf) =>
                            {
                                 conf.AddJsonFile("appsettings.Test.json");
                            }
                        );
                }
            )
            // Create the host using the CreateDefaultClient method.
            .CreateDefaultClient();
        await _playwrightFixture.GotoPageAsync(
            url, async (page) =>
            {
                // Click text=Home
                await page.Locator("text=Home").ClickAsync();
                await page.WaitForURLAsync($"{url}/");
                // Click text=Hello, world!
                await page.Locator("text=Hello, world!").IsVisibleAsync();

                // Click text=Counter
                await page.Locator("text=Counter").ClickAsync();
                await page.WaitForURLAsync($"{url}/counter");
                // Click h1:has-text("Counter")
                await page.Locator("h1:has-text(\"Counter\")").IsVisibleAsync();
                // Click text=Click me
                await page.Locator("text=Click me").ClickAsync();
                // Click text=Current count: 1
                await page.Locator("text=Current count: 1").IsVisibleAsync();
                // Click text=Click me
                await page.Locator("text=Click me").ClickAsync();
                // Click text=Current count: 2
                await page.Locator("text=Current count: 2")
                    .IsVisibleAsync();
            },
            BrowserEnum.Chromium
        );
    }
}