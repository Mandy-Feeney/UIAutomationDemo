using Microsoft.Playwright;
using OpenQA.Selenium;
using UIAutomationDemo.Specs.Drivers;
using PlaywrightBrowserType = UIAutomationDemo.Specs.Drivers.PlaywrightBrowserType;

namespace UIAutomationDemo.Specs.Hooks;

[Binding]
public sealed class LifecycleHooks
{
    [BeforeScenario("playwright")]
    public static async Task ConfigurePlaywright(ScenarioContext scenarioContext)
    {
        BrowserTypeLaunchOptions options = new() { Headless = false };

        PlaywrightDriver playwrightDriver = new();
        IPage page = await playwrightDriver.Initialize(PlaywrightBrowserType.Chromium, options);

        scenarioContext.ScenarioContainer.RegisterInstanceAs(playwrightDriver);
        scenarioContext.ScenarioContainer.RegisterInstanceAs(page);
    }

    [AfterScenario("playwright")]
    public static async Task CleanUpPlaywright(ScenarioContext scenarioContext)
    {
        IPage page = scenarioContext.ScenarioContainer.Resolve<IPage>();
        PlaywrightDriver playwrightDriver = scenarioContext.ScenarioContainer.Resolve<PlaywrightDriver>();
        await page.CloseAsync();
        playwrightDriver.Dispose();
    }

    [BeforeScenario("selenium")]
    public static void ConfigureSelenium(ScenarioContext scenarioContext)
    {
        SeleniumDriver seleniumDriver = new();
        IWebDriver driver = seleniumDriver.Initialize(SeleniumBrowserType.Chrome);

        scenarioContext.ScenarioContainer.RegisterInstanceAs(driver);
    }

    [AfterScenario("selenium")]
    public static void CleanUpSelenium(ScenarioContext scenarioContext)
    {
        IWebDriver driver = scenarioContext.ScenarioContainer.Resolve<IWebDriver>();
        driver.Dispose();
    }
}