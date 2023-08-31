using StoriesPlaywright.Test.Infrastructure;

namespace StoriesPlaywright.Test;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class QuickgridTest : BlazorTest
{
    [Test]
    public async Task NumberOfRows_ShouldBe_5()
    {
        // Ensure that the client project is running
        // await Page.PauseAsync();
        // await Page.GotoAsync("https://localhost:7297/?path=/docs/example-button--docs");
        await Page.GotoAsync(RootUri.AbsoluteUri);
        await Page.GetByRole(AriaRole.Button, new() { Name = "Quickgrid" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Default" }).Nth(1).ClickAsync();
        var app =  Page.FrameLocator("iframe").Locator("#app");

        await app.Locator(".quickgrid")
                            .WaitForAsync(new LocatorWaitForOptions() { State = WaitForSelectorState.Attached });
        
        var quickGrid = app.Locator("table>tbody>tr");
        var count = await quickGrid.CountAsync();
        Assert.That(count, Is.EqualTo(5));
    }

    [Test]
    public async Task EnableSearch_ShouldReturn_1()
    {
        // // Ensure that the client project is running
        // await Page.PauseAsync();
        await Page.GotoAsync(RootUri.AbsoluteUri);

        await Page.GetByRole(AriaRole.Button, new() { Name = "Quickgrid" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Enable Search" }).ClickAsync();
        var app = Page.FrameLocator("iframe").Locator("#app");

        await app.Locator(".quickgrid")
            .WaitForAsync(new LocatorWaitForOptions() { State = WaitForSelectorState.Attached });

        await app.GetByRole(AriaRole.Button).ClickAsync();

        await app.GetByPlaceholder("Search ...").ClickAsync();

        await app.GetByPlaceholder("Search ...").FillAsync("warm");

        app.GetByPlaceholder("Search ...").PressAsync("Enter").Wait();

        var quickGrid = Page.FrameLocator("iframe").Locator(".quickgrid");

        var count = await quickGrid.CountAsync();
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public async Task EnableSort_Should_SortTable()
    {
        await Page.GotoAsync(RootUri.AbsoluteUri);

        await Page.GetByRole(AriaRole.Button, new() { Name = "Quickgrid" }).ClickAsync();

        await Page.GetByRole(AriaRole.Link, new() { Name = "Enable Sorting" }).ClickAsync();
        
        var app = Page.FrameLocator("iframe").Locator("#app");
        await app.Locator(".quickgrid")
            .WaitForAsync(new LocatorWaitForOptions() { State = WaitForSelectorState.Attached });
        
         app.GetByRole(AriaRole.Button, new() { Name = "Temperature Celsius" })
            .ClickAsync().Wait();
         
         var sortColumn =  Page.FrameLocator("iframe").GetByRole(AriaRole.Columnheader, new() { Name = "Temperature Celsius" });
           await Expect(sortColumn).ToHaveAttributeAsync("aria-sort", "ascending");

           app.GetByRole(AriaRole.Button, new() { Name = "Temperature Celsius" })
               .ClickAsync().Wait();

           sortColumn = Page.FrameLocator("iframe").GetByRole(
               AriaRole.Columnheader, new() { Name = "Temperature Celsius" }
           );
           await Expect(sortColumn).ToHaveAttributeAsync("aria-sort", "descending");
    }

    [Test]
    public async Task EnableTemplate_Should_AddTemplateToGrid()
    {
        await Page.GotoAsync(RootUri.AbsoluteUri);

        await Page.GetByRole(AriaRole.Button, new() { Name = "Quickgrid" }).ClickAsync();

        await Page.GetByRole(AriaRole.Link, new() { Name = "Enable Template" }).ClickAsync();

        var app = Page.FrameLocator("iframe").Locator("#app");
        await app.Locator(".quickgrid")
            .WaitForAsync(new LocatorWaitForOptions() { State = WaitForSelectorState.Attached });

        var templateCount = await app.Locator("i").CountAsync();
        Assert.That(templateCount, Is.EqualTo(5));
    }

    [Test]
    public async Task EnablePagination_Should_UpdateNrOfPages()
    {
        await Page.GotoAsync(RootUri.AbsoluteUri);

        await Page.GetByRole(AriaRole.Button, new() { Name = "Quickgrid" }).ClickAsync();

        await Page.GetByRole(AriaRole.Link, new() { Name = "Enable Pagination" }).ClickAsync();

        var app = Page.FrameLocator("iframe").Locator("#app");
        await app.Locator(".quickgrid")
            .WaitForAsync(new LocatorWaitForOptions() { State = WaitForSelectorState.Attached });

        await app.GetByPlaceholder("2").ClickAsync();

        await app.GetByPlaceholder("2").FillAsync("3");

        app.GetByPlaceholder("2").PressAsync("Enter").Wait();

        var navigation =  await app.GetByRole(AriaRole.Navigation).Locator(".pagination-text").InnerTextAsync();
        Assert.That(navigation, Is.EqualTo("Page 1 of 3"));
    }
}