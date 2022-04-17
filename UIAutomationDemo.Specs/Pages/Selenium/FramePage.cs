using OpenQA.Selenium;

namespace UIAutomationDemo.Specs.Pages.Selenium;

public class FramePage : BasePage
{
    private static string Url => "https://letcode.in/frame";

    private static By TopIFrame => By.Id("firstFr");
    private static By InnerFrame => By.CssSelector("[src='innerFrame']");
    private static By FirstNameField => By.CssSelector("[name='fname']");
    private static By LastNameField => By.CssSelector("[name='lname']");
    private static By EmailField => By.CssSelector("[name='email']");

    public FramePage(IWebDriver driver) : base(driver, Url) { }

    public void EnterFirstName(string firstName)
    {
        _driver.SwitchTo().Frame(_driver.FindElement(TopIFrame));
        _driver.FindElement(FirstNameField).SendKeys(firstName);
        _driver.SwitchTo().ParentFrame();
    }

    public void EnterLastName(string lastName)
    {
        _driver.SwitchTo().Frame(_driver.FindElement(TopIFrame));
        _driver.FindElement(LastNameField).SendKeys(lastName);
        _driver.SwitchTo().ParentFrame();
    }

    public void EnterEmail(string email)
    {
        _driver.SwitchTo().Frame(_driver.FindElement(TopIFrame)).SwitchTo().Frame(_driver.FindElement(InnerFrame));
        _driver.FindElement(EmailField).SendKeys(email);
        _driver.SwitchTo().ParentFrame().SwitchTo().ParentFrame();
    }

    public string GetEnteredFirstName()
    {
        _driver.SwitchTo().Frame(_driver.FindElement(TopIFrame));
        string firstName = _driver.FindElement(FirstNameField).GetAttribute("value");
        _driver.SwitchTo().ParentFrame();

        return firstName;
    }

    public string GetEnteredLastName()
    {
        _driver.SwitchTo().Frame(_driver.FindElement(TopIFrame));
        string lastName = _driver.FindElement(LastNameField).GetAttribute("value");
        _driver.SwitchTo().ParentFrame();

        return lastName;
    }

    public string GetEnteredEmail()
    {
        _driver.SwitchTo().Frame(_driver.FindElement(TopIFrame)).SwitchTo().Frame(_driver.FindElement(InnerFrame));
        string email = _driver.FindElement(EmailField).GetAttribute("value");
        _driver.SwitchTo().ParentFrame().SwitchTo().ParentFrame();

        return email;
    }
}