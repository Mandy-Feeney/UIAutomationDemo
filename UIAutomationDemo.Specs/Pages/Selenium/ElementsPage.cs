using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UIAutomationDemo.Specs.Pages.Selenium;

public class ElementsPage : BasePage
{
    private static string Url => "https://letcode.in/elements";

    private static By GitUsernameField => By.CssSelector("[name='username']");
    private static By GitSearchButton => By.Id("search");
    private static By GitProfile => By.TagName("app-usercard");
    private static By GitUsernameTitle => By.CssSelector("app-usercard .title");
    private static By GitUsernameImage => By.CssSelector("app-usercard img");
    private static By GitPublicRepos => By.XPath("(.//app-usercard//span[@class='tag is-info'])[1]");

    public ElementsPage(IWebDriver driver) : base(driver, Url) { }

    public void SearchGitUsername(string gitUsername)
    {
        _driver.FindElement(GitUsernameField).SendKeys(gitUsername);
        _driver.FindElement(GitSearchButton).Click();
    }

    public string GetGitUsername() => _driver.FindElement(GitUsernameTitle).Text;

    public string GetGitPublicRepos() => _driver.FindElement(GitPublicRepos).Text;

    public bool HasGitProfileBeenFound()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(GitProfile));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool HasGitProfileImage() => _driver.FindElements(GitUsernameImage).Count > 0;
}
