using OpenQA.Selenium;

namespace UIAutomationDemo.Specs.Pages.Selenium;

public class RadioAndCheckboxesPage : BasePage
{
    private static string Url => "https://letcode.in/radio";
    private static By TermsAndConditionsCheckbox => By.XPath("(//input[@type='checkbox'])[2]");

    public RadioAndCheckboxesPage(IWebDriver driver) : base(driver, Url) { }

    public void SelectRadioOption(string radioOptionId) => _driver.FindElement(By.Id(radioOptionId.ToLower())).Click();

    public void CheckTermsAndConditions()
    {
        IWebElement checkbox = _driver.FindElement(TermsAndConditionsCheckbox);
        if (checkbox.Selected) return;

        checkbox.Click();
    }

    public bool IsRadioOptionSelected(string radioOptionId) => _driver.FindElement(By.Id(radioOptionId.ToLower())).Selected;

    public bool IsRadioOptionDisabled(string radioOptionId) => !_driver.FindElement(By.Id(radioOptionId.ToLower())).Enabled;

    public bool IsTermsAndConditionsChecked() => _driver.FindElement(TermsAndConditionsCheckbox).Selected;
}