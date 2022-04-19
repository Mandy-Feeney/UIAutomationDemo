using Microsoft.Playwright;

namespace UIAutomationDemo.Specs.Pages.Playwright;

public class WindowsPage : BasePage
{
    private static string Url => "https://letcode.in/windows";
    private static string OpenHomepageButton => "#home";
    private static string MultipleWindowsButton => "#multi";

    public WindowsPage(IPage page) : base(page, Url) { }

    public async Task OpenHomepageTab()
    {
        var newPage = await _page.Context.RunAndWaitForPageAsync(async () => await _page.ClickAsync(OpenHomepageButton));
        await newPage.WaitForLoadStateAsync();
    }

    public async Task ClosePage(int index) => await _page.Context.Pages[index].CloseAsync();

    public async Task CloseAllAdditionalWindows()
    {
        while(_page.Context.Pages.Count > 1)
            await _page.Context.Pages.Last().CloseAsync();
    }

    public int GetNumberOfOpenedPages() => _page.Context.Pages.Count;

    public async Task<string> GetMostRecentOpenedPageTitle() => await _page.Context.Pages.Last().TitleAsync();

    public async Task OpenMultipleWindows()
    { 
        var newPage = await _page.Context.RunAndWaitForPageAsync(async () => await _page.ClickAsync(MultipleWindowsButton));
        await newPage.WaitForLoadStateAsync();
    }

    public bool IsPageOpenWithTitle(string pageTitle) => _page.Context.Pages.Any(p => p.TitleAsync().Result.Equals(pageTitle));

    public bool IsPageOpenWithUrl(string url) => _page.Context.Pages.Any(p => p.Url.Contains(url));
}