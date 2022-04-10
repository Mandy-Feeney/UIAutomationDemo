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
        _browser = null;

        switch(browserType)
        {
            case PlaywrightBrowserType.Chromium:
                _browser = await _playwright.Chromium.LaunchAsync(launchOptions);
                break;
            case PlaywrightBrowserType.Firefox:
                _browser = await _playwright.Firefox.LaunchAsync(launchOptions);
                break;
            case PlaywrightBrowserType.Webkit:
                _browser = await _playwright.Webkit.LaunchAsync(launchOptions);
                break;
            default: 
                throw new ArgumentException(nameof(browserType));
        }

        Page = await _browser.NewPageAsync();
        return Page;
    }

    public void Dispose()
    {
        _browser?.DisposeAsync();
        _playwright?.Dispose();
    }
}