using Microsoft.Playwright;

namespace UIAutomationDemo.Specs.Pages.Playwright;

public abstract class BasePage
{
    protected readonly IPage _page;
    protected readonly string _url;

    public BasePage(IPage page, string url)
    {
        _page = page;
        _url = url;
    }

    public async Task<string> PageTitle() => await _page.TitleAsync();

    public async Task Goto() => await _page.GotoAsync(_url);
}