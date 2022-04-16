using OpenQA.Selenium;

namespace UIAutomationDemo.Specs.Pages.Selenium;

public abstract class BasePage
{
    protected readonly IWebDriver _driver;
    protected readonly string _url;

    public BasePage(IWebDriver driver, string url)
    {
        _driver = driver;
        _url = url;
    }

    public string PageTitle() => _driver.Title;

    public void Goto() => _driver.Navigate().GoToUrl(_url);
}