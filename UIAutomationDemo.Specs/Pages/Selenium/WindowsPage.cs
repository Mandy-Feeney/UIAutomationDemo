using OpenQA.Selenium;

namespace UIAutomationDemo.Specs.Pages.Selenium;

public class WindowsPage : BasePage
{
    private static string Url => "https://letcode.in/windows";
    private static By OpenHomepageButton => By.Id("home");
    private static By MultipleWindowsButton => By.Id("multi");

    public WindowsPage(IWebDriver driver) : base(driver, Url) { }

    public void OpenHomepageTab() => _driver.FindElement(OpenHomepageButton).Click();

    public void ClosePage(int index)
    {
        string windowHandle = _driver.WindowHandles[index];
        _driver.SwitchTo().Window(windowHandle).Close();
    }

    public void CloseAllAdditionalWindows()
    {
        while (_driver.WindowHandles.Count > 1)
        {
            string windowHandle = _driver.WindowHandles.Last();
            _driver.SwitchTo().Window(windowHandle).Close();
        }
    }

    public int GetNumberOfOpenedPages() => _driver.WindowHandles.Count;

    public string GetMostRecentOpenedPageTitle()
    {
        string windowHandle = _driver.WindowHandles.Last();
        return _driver.SwitchTo().Window(windowHandle).Title;
    }

    public void OpenMultipleWindows() => _driver.FindElement(MultipleWindowsButton).Click();

    public bool IsPageOpenWithTitle(string pageTitle)
    {
        foreach(string windowHandle in _driver.WindowHandles)
        {
            bool isOpen = _driver.SwitchTo().Window(windowHandle).Title.Equals(pageTitle);
            if (isOpen) return true;
        }

        return false;
    }

    public bool IsPageOpenWithUrl(string url)
    {
        foreach (string windowHandle in _driver.WindowHandles)
        {
            bool isOpen = _driver.SwitchTo().Window(windowHandle).Url.Contains(url);
            if (isOpen) return true;
        }

        return false;
    }
}