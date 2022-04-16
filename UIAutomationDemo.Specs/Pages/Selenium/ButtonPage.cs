using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UIAutomationDemo.Specs.Pages.Selenium;

public class ButtonPage : BasePage
{
    private static string Url => "https://letcode.in/buttons";

    private static By HomeButton => By.Id("home");
    private static By LocationButton => By.Id("position");
    private static By ColourButton => By.Id("color");
    private static By SizeButton => By.Id("property");
    private static By DisabledButton => By.Id("isDisabled");
    private static By HoldButton => By.CssSelector("#isDisabled.is-primary");

    public ButtonPage(IWebDriver driver) : base(driver, Url) { }

    public void ClickHomeButton() => _driver.FindElement(HomeButton).Click();

    public (float, float) GetCoordinatesOfButton()
    {
        var button = _driver.FindElement(LocationButton);
        return (button.Location.X, button.Location.Y);
    }

    public string GetColourOfButton()
    {
        return _driver.FindElement(ColourButton).GetCssValue("background-color");
    }

    public (float, float) GetSizeOfButton()
    {
        var button = _driver.FindElement(SizeButton);
        return (button.Size.Width, button.Size.Height);
    }

    public bool IsButtonDisabled() => !_driver.FindElement(DisabledButton).Enabled;

    public void LongClickButton(int holdClickInSeconds)
    {
        var button = _driver.FindElement(HoldButton);
        Actions action = new(_driver);
        action.ClickAndHold(button).Build().Perform();
        Thread.Sleep(holdClickInSeconds * 1000);
        action.Release().Build().Perform();
    }

    public string GetLongClickButtonText() => _driver.FindElement(HoldButton).Text;
}
