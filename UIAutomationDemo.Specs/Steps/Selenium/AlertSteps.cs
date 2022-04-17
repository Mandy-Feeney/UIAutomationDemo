using UIAutomationDemo.Specs.Pages.Selenium;

namespace UIAutomationDemo.Specs.Steps.Selenium;

[Binding]
[Scope(Tag = "selenium")]
public class AlertSteps
{
    private readonly AlertPage _alertPage;
    private string _promptText = string.Empty;
    private string _dialogMessage = string.Empty;

    public AlertSteps(AlertPage alertPage) => _alertPage = alertPage;

    [Given(@"I am on the Alert page")]
    public void GivenIAmOnTheAlertPage()
    {
        _alertPage.Goto();
    }

    [Given(@"I want to accept an open alert")]
    [Given("I want to dismiss an open alert")]
    [Given("I want to dismiss it")]
    [Given(@"I want to get an open alert's message")]
    public void GivenAlerts() { }

    [Given(@"I want to confirm an open prompt alert with ""([^""]*)""")]
    public void GivenIWantToConfirmAnOpenPromptAlertWith(string promptText)
    {
        _promptText = promptText;
    }

    [When(@"I open the simple alert and accept it")]
    public void WhenIAcceptTheSimpleAlert()
    {
        _alertPage.OpenSimpleAlert();
        _alertPage.AcceptAlert();
    }

    [When(@"I open the confirm alert and dismiss it")]
    public void WhenIDismissTheConfirmAlert()
    {
        _alertPage.OpenConfirmAlert();
        _dialogMessage = _alertPage.GetDialogMessage();
        _alertPage.DismissAlert();
    }

    [When(@"I open and confirm the prompt alert")]
    public void WhenIConfirmThePromptAlert()
    {
        _alertPage.OpenPromptAlert();
        _alertPage.EnterPromptInAlert(_promptText);
        _alertPage.AcceptAlert();
    }

    [When(@"I open the modern alert and close it")]
    public void WhenICloseTheModernAlert()
    {
        _alertPage.OpenModernAlert();
        _alertPage.CloseModernAlert();
    }

    [Then(@"the alert should be closed")]
    public void ThenTheAlertShouldBeClosed()
    {
        _alertPage.NavigateToWorkspaces();
        string pageTitle = _alertPage.PageTitle();
        pageTitle.Should().Be("LetCode - Testing Hub");
    }

    [Then(@"I should have the alert text")]
    public void ThenIShouldHaveTheAlertText()
    {
        _dialogMessage.Should().Be("Are you happy with LetCode?");
    }
}