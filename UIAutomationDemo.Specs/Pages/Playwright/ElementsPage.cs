using Microsoft.Playwright;

namespace UIAutomationDemo.Specs.Pages.Playwright;

public class ElementsPage : BasePage
{
    private static string Url => "https://letcode.in/elements";

    private static string GitUsernameField => "[name='username']";
    private static string GitSearchButton => "#search";
    private static string GitProfile => "app-usercard";
    private static string GitUsernameTitle => "app-usercard .title";
    private static string GitUsernameImage => "app-usercard img";
    private static string GitPublicRepos => "xpath=(.//app-usercard//span[@class='tag is-info'])[1]";

    public ElementsPage(IPage page) : base(page, Url) { }

    public async Task SearchGitUsername(string gitUsername)
    {
        await _page.TypeAsync(GitUsernameField, gitUsername);
        await _page.ClickAsync(GitSearchButton);
    }

    public async Task<string> GetGitUsername() => await _page.InnerTextAsync(GitUsernameTitle);

    public async Task<string> GetGitPublicRepos() => await _page.InnerTextAsync(GitPublicRepos);

    public async Task<bool> HasGitProfileBeenFound()
    {
        try
        {
            await _page.Locator(GitProfile).WaitForAsync(new LocatorWaitForOptions() { Timeout = 5000 });
            return true;
        } 
        catch 
        { 
            return false; 
        }
    }

    public async Task<bool> HasGitProfileImage() => await _page.Locator(GitUsernameImage).CountAsync() > 0;
}
