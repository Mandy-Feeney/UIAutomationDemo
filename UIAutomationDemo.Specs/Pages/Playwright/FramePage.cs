using Microsoft.Playwright;

namespace UIAutomationDemo.Specs.Pages.Playwright;

public class FramePage : BasePage
{
    private static string Url => "https://letcode.in/frame";

    private static string TopIFrame => "#firstFr";
    private static string InnerFrame => "[src='innerFrame']";
    private static string FirstNameField => "[name='fname']";
    private static string LastNameField => "[name='lname']";
    private static string EmailField => "[name='email']";

    public FramePage(IPage page) : base(page, Url) { }

    public async Task EnterFirstName(string firstName) => 
        await _page.FrameLocator(TopIFrame).Locator(FirstNameField).FillAsync(firstName);

    public async Task EnterLastName(string lastName) =>
        await _page.FrameLocator(TopIFrame).Locator(LastNameField).FillAsync(lastName);

    public async Task EnterEmail(string email) =>
        await _page.FrameLocator(TopIFrame).FrameLocator(InnerFrame).Locator(EmailField).FillAsync(email);

    public async Task<string> GetEnteredFirstName() =>
        await _page.FrameLocator(TopIFrame).Locator(FirstNameField).InputValueAsync();

    public async Task<string> GetEnteredLastName() =>
        await _page.FrameLocator(TopIFrame).Locator(LastNameField).InputValueAsync();

    public async Task<string> GetEnteredEmail() =>
        await _page.FrameLocator(TopIFrame).FrameLocator(InnerFrame).Locator(EmailField).InputValueAsync();
}