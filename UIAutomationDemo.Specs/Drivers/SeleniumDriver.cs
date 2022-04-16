using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace UIAutomationDemo.Specs.Drivers;

public enum SeleniumBrowserType
{
    Chrome,
    Firefox,
    Edge,
    Safari
}

public class SeleniumDriver
{
    public IWebDriver? WebDriver { get; private set; }

    public IWebDriver Initialize(SeleniumBrowserType browserType)
    {
        IWebDriver? driver = browserType switch
        {
            SeleniumBrowserType.Chrome => new ChromeDriver(),
            SeleniumBrowserType.Firefox => new FirefoxDriver(),
            SeleniumBrowserType.Edge => new EdgeDriver(),
            SeleniumBrowserType.Safari => new SafariDriver(),
            _ => throw new ArgumentException("Browser not supported", nameof(browserType)),
        };

        WebDriver = driver;
        WebDriver.Manage().Window.Maximize();

        return WebDriver;
    }
}
