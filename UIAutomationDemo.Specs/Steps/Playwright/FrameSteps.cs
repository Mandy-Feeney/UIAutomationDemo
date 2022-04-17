using UIAutomationDemo.Specs.Pages.Playwright;

namespace UIAutomationDemo.Specs.Steps.Playwright;

[Binding]
[Scope(Tag = "playwright")]
public class FrameSteps
{
    private readonly FramePage _framePage;
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _email = string.Empty;

    public FrameSteps(FramePage framePage) => _framePage = framePage;

    [Given(@"I am on the Frame page")]
    public async Task GivenIAmOnTheFramePage()
    {
        await _framePage.Goto();
    }

    [When(@"I enter the first name ""([^""]*)""")]
    public async Task WhenIEnterTheFirstName(string firstName)
    {
        _firstName = firstName;
        await _framePage.EnterFirstName(firstName);
    }

    [When(@"I enter the last name ""([^""]*)""")]
    public async Task WhenIEnterTheLastName(string lastName)
    {
        _lastName = lastName;
        await _framePage.EnterLastName(lastName);
    }

    [When(@"I enter the email ""([^""]*)""")]
    public async Task WhenIEnterTheEmail(string email)
    {
        _email = email;
        await _framePage.EnterEmail(email);
    }

    [Then(@"I should see these are all entered into the fields")]
    public async Task ThenIShouldSeeTheseAreAllEnteredIntoTheFields()
    {
        string actualFirstname = await _framePage.GetEnteredFirstName();
        actualFirstname.Should().Be(_firstName);

        string actualLastName = await _framePage.GetEnteredLastName();
        actualLastName.Should().Be(_lastName);

        string actualEmail = await _framePage.GetEnteredEmail();
        actualEmail.Should().Be(_email);
    }
}