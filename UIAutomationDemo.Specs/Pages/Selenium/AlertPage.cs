using OpenQA.Selenium;

namespace UIAutomationDemo.Specs.Pages.Selenium;

public class AlertPage : BasePage
{
    private static string Url => "https://letcode.in/alert";

    private static By SimpleAlertButton => By.Id("accept");
    private static By ConfirmAlertButton => By.Id("confirm");
    private static By PromptAlertButton => By.Id("prompt");
    private static By ModernAlertButton => By.Id("modern");
    private static By ModernAlertCloseButton => By.CssSelector(".modal-close");

    public AlertPage(IWebDriver driver) : base(driver, Url) { }

    public void OpenSimpleAlert() => _driver.FindElement(SimpleAlertButton).Click();

    public void OpenConfirmAlert() => _driver.FindElement(ConfirmAlertButton).Click();

    public void OpenPromptAlert() => _driver.FindElement(PromptAlertButton).Click();

    public void OpenModernAlert() => _driver.FindElement(ModernAlertButton).Click();

    public void CloseModernAlert() => _driver.FindElement(ModernAlertCloseButton).Click();

    public void AcceptAlert() => _driver.SwitchTo().Alert().Accept();

    public void EnterPromptInAlert(string promptText) => _driver.SwitchTo().Alert().SendKeys(promptText);

    public void DismissAlert() => _driver.SwitchTo().Alert().Dismiss();

    public string GetDialogMessage() =>_driver.SwitchTo().Alert().Text;
}