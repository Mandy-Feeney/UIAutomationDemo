using UIAutomationDemo.Specs.Pages.Playwright;

namespace UIAutomationDemo.Specs.Steps.Playwright;

[Binding]
[Scope(Tag = "playwright")]
public class WindowsSteps
{
    private readonly WindowsPage _windowsPage;

    public WindowsSteps(WindowsPage windowsPage) => _windowsPage = windowsPage;

    [Given(@"I am on the Windows page")]
    public async Task GivenIAmOnTheWindowsPage()
    {
        await _windowsPage.Goto();
    }

    [When(@"I open another tab for the Homepage")]
    public async Task WhenIOpenAnotherTabForTheHomepage()
    {
        await _windowsPage.OpenHomepageTab();
    }

    [Then(@"I should see that (.*) tabs are open")]
    [Then(@"I should see that (.*) windows are open")]
    public void ThenIShouldSeeThatTabsOrWindowsAreOpen(int expectedNoOfOpenedTabsOrWindows)
    {
        int actualNoOfOpenedTabsOrWindows = _windowsPage.GetNumberOfOpenedPages();
        actualNoOfOpenedTabsOrWindows.Should().Be(expectedNoOfOpenedTabsOrWindows);
    }

    [Then(@"I should see the new tab is for the Homepage")]
    public async Task ThenIShouldSeeTheNewTabIsForTheHomepage()
    {
        string newTabPageTitle = await _windowsPage.GetMostRecentOpenedPageTitle();
        newTabPageTitle.Should().Be("LetCode - Testing Hub");
    }

    [When(@"I close the Homepage tab")]
    public async Task WhenICloseTheTheHomepageTab()
    {
        await _windowsPage.ClosePage(1);
    }

    [Then(@"I should see the Homepage tab has been closed")]
    public void ThenIShouldSeeTheHomepageTabHasBeenClosed()
    {
        bool isPageOpen = _windowsPage.IsPageOpenWithTitle("LetCode - Testing Hub");
        isPageOpen.Should().BeFalse();
    }

    [When(@"I open multiple windows")]
    public async Task WhenIOpenMultipleWindows()
    {
        await _windowsPage.OpenMultipleWindows();
    }

    [Then(@"I should see that one window is for Alerts")]
    public void ThenIShouldSeeThatOneWindowIsForAlerts()
    {
        bool isPageOpen = _windowsPage.IsPageOpenWithUrl("alert");
        isPageOpen.Should().BeTrue();
    }

    [Then(@"I should see that one window is for Dropdowns")]
    public void ThenIShouldSeeThatOneWindowIsForDropdowns()
    {
        bool isPageOpen = _windowsPage.IsPageOpenWithUrl("dropdowns");
        isPageOpen.Should().BeTrue();
    }

    [When(@"I close all windows but the first")]
    public async Task WhenICloseAllWindowsButTheFirst()
    {
        await _windowsPage.CloseAllAdditionalWindows();
    }

    [Then(@"I should see only the Windows page is open")]
    public async Task ThenIShouldSeeOnlyTheWindowsPageIsOpen()
    {
        int numberOfOpenedPages = _windowsPage.GetNumberOfOpenedPages();
        string pageTitle = await _windowsPage.GetMostRecentOpenedPageTitle();

        numberOfOpenedPages.Should().Be(1);
        pageTitle.Should().Be("Window handling - LetCode");
    }
}