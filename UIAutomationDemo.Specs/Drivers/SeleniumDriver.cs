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
        IWebDriver? driver = null;

        switch (browserType)
        {
            case SeleniumBrowserType.Chrome:
                driver = new ChromeDriver();
                break;
            case SeleniumBrowserType.Firefox:
                driver = new FirefoxDriver();
                break;
            case SeleniumBrowserType.Edge:
                driver = new EdgeDriver();
                break;
            case SeleniumBrowserType.Safari:
                driver = new SafariDriver();
                break;
            default:
                throw new ArgumentException(nameof(browserType));
        }

        WebDriver = driver;
        return driver;
    }
}
