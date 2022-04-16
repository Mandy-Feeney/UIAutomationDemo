using OpenQA.Selenium;

namespace UIAutomationDemo.Specs.Pages.Selenium;

public class InputFieldPage : BasePage
{
    private static string Url => "https://letcode.in/edit";

    private static By FullNameField => By.Id("fullName");
    private static By AppendTextField => By.Id("join");
    private static By ClearField => By.Id("clearMe");
    private static By DisabledField => By.Id("noEdit");
    private static By ReadonlyField => By.Id("dontwrite");

    public InputFieldPage(IWebDriver driver) : base(driver, Url) { }

    public void EnterFullName(string text)
    {
        _driver.FindElement(FullNameField).Clear();
        _driver.FindElement(FullNameField).SendKeys(text);
    }

    public void AppendText(string text) => _driver.FindElement(AppendTextField).SendKeys(text);

    public void ClearTextInField() => _driver.FindElement(ClearField).Clear();

    public string GetEnteredFullname() => _driver.FindElement(FullNameField).GetAttribute("value");

    public string GetEnteredAppendedText() => _driver.FindElement(AppendTextField).GetAttribute("value");

    public string GetClearedFieldText() =>_driver.FindElement(ClearField).GetAttribute("value");

    public bool IsFieldDisabled() => !_driver.FindElement(DisabledField).Enabled;

    public bool IsFieldEditable() => !bool.Parse(_driver.FindElement(ReadonlyField).GetAttribute("readonly"));
}
