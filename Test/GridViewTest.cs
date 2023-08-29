using StoriesPlaywright.Test.Infrastructure;

namespace StoriesPlaywright.Test;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class GridViewTest : BlazorTest
{
    [Test]
    public async Task DateFormat_Change()
    {
        await Page.GotoAsync(RootUri.AbsoluteUri);

        await Page.GotoAsync($"{RootUri.AbsoluteUri}/?path=/docs/example-button--docs");

        await Page.GetByRole(AriaRole.Button, new() { Name = "GridView" }).ClickAsync();

        await Page.GetByRole(AriaRole.Link, new() { Name = "Default" }).Nth(1).ClickAsync();

        await Page.GetByPlaceholder("Edit string...").ClickAsync();

        await Page.GetByPlaceholder("Edit string...").FillAsync("dd MMMM yyyy");

        await Page.FrameLocator("iframe").GetByRole(AriaRole.Cell, new() { Name = "30 August 2023" }).ClickAsync();

    }
}