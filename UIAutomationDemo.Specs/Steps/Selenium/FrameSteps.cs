using UIAutomationDemo.Specs.Pages.Selenium;

namespace UIAutomationDemo.Specs.Steps.Selenium;

[Binding]
[Scope(Tag = "selenium")]
public class FrameSteps
{
    private readonly FramePage _framePage;
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _email = string.Empty;

    public FrameSteps(FramePage framePage) => _framePage = framePage;

    [Given(@"I am on the Frame page")]
    public void GivenIAmOnTheFramePage()
    {
        _framePage.Goto();
    }

    [When(@"I enter the first name ""([^""]*)""")]
    public void WhenIEnterTheFirstName(string firstName)
    {
        _firstName = firstName;
        _framePage.EnterFirstName(firstName);
    }

    [When(@"I enter the last name ""([^""]*)""")]
    public void WhenIEnterTheLastName(string lastName)
    {
        _lastName = lastName;
        _framePage.EnterLastName(lastName);
    }

    [When(@"I enter the email ""([^""]*)""")]
    public void WhenIEnterTheEmail(string email)
    {
        _email = email;
        _framePage.EnterEmail(email);
    }

    [Then(@"I should see these are all entered into the fields")]
    public void ThenIShouldSeeTheseAreAllEnteredIntoTheFields()
    {
        string actualFirstname = _framePage.GetEnteredFirstName();
        actualFirstname.Should().Be(_firstName);

        string actualLastName = _framePage.GetEnteredLastName();
        actualLastName.Should().Be(_lastName);

        string actualEmail = _framePage.GetEnteredEmail();
        actualEmail.Should().Be(_email);
    }
}