using Microsoft.Playwright;

namespace UIAutomationDemo.Specs.Pages.Playwright;

public class ButtonPage : BasePage
{
    private static string Url => "https://letcode.in/buttons";

    private static string HomeButton => "#home";
    private static string LocationButton => "#position";
    private static string ColourButton => "#color";
    private static string SizeButton => "#property";
    private static string DisabledButton => "#isDisabled";
    private static string HoldButton => "#isDisabled.is-primary";

    public ButtonPage(IPage page) : base(page, Url) { }

    public async Task ClickHomeButton() => await _page.ClickAsync(HomeButton);

    public async Task<(float?, float?)> GetCoordinatesOfButton()
    {
        var button = _page.Locator(LocationButton);

        LocatorBoundingBoxResult? buttonDetails = await button.BoundingBoxAsync();
        return (buttonDetails?.X, buttonDetails?.Y);
    }

    public async Task<string> GetColourOfButton()
    {
        var button = _page.Locator(ColourButton);
        return await button.EvaluateAsync<string>(@"ele => 
               window.getComputedStyle(ele).getPropertyValue('background-color')"
        );
    }

    public async Task<(float?, float?)> GetSizeOfButton()
    {
        var button = _page.Locator(SizeButton);

        LocatorBoundingBoxResult? buttonDetails = await button.BoundingBoxAsync();
        return (buttonDetails?.Width, buttonDetails?.Height);
    }

    public async Task<bool> IsButtonDisabled() => await _page.IsDisabledAsync(DisabledButton);

    public async Task LongClickButton(int holdClickInSeconds) =>    
        await _page.ClickAsync(HoldButton, new() { Delay = holdClickInSeconds * 1000 });

    public async Task<string> GetLongClickButtonText() => await _page.InnerTextAsync(HoldButton);
}
