using Microsoft.Playwright;

namespace UIAutomationDemo.Specs.Drivers;

public enum PlaywrightBrowserType
{
    Chromium,
    Firefox,
    Webkit
}

public class PlaywrightDriver
{
    private IPlaywright? _playwright;

    private IBrowser? _browser;
    public IPage? Page { get; private set; }

    public async Task<IPage> Initialize(PlaywrightBrowserType browserType, BrowserTypeLaunchOptions launchOptions)
    {
        _playwright = await Playwright.CreateAsync();
        IBrowser browser = browserType switch
        {
            PlaywrightBrowserType.Chromium => await _playwright.Chromium.LaunchAsync(launchOptions),
            PlaywrightBrowserType.Firefox => await _playwright.Firefox.LaunchAsync(launchOptions),
            PlaywrightBrowserType.Webkit => await _playwright.Webkit.LaunchAsync(launchOptions),
            _ => throw new ArgumentException("Browser not supported", nameof(browserType)),
        };

        _browser = browser;
        Page = await browser.NewPageAsync();
        await Page.SetViewportSizeAsync(1280, 960);

        return Page;
    }

    public void Dispose()
    {
        _browser?.DisposeAsync();
        _playwright?.Dispose();
    }
}