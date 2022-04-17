using UIAutomationDemo.Specs.Pages.Playwright;

namespace UIAutomationDemo.Specs.Steps.Playwright;

[Binding]
[Scope(Tag = "playwright")]
public class AlertSteps
{
    private readonly AlertPage _alertPage;

    public AlertSteps(AlertPage alertPage) => _alertPage = alertPage;

    [Given(@"I am on the Alert page")]
    public async Task GivenIAmOnTheAlertPage()
    {
        await _alertPage.Goto();
    }

    [Given(@"I want to accept an open alert")]
    public void GivenIWantToAcceptAnOpenAlert()
    {
        _alertPage.AcceptAlert();
    }

    [Given("I want to dismiss an open alert")]
    [Given("I want to dismiss it")]
    public void GivenIWantToDismissAnOpenAlert()
    {
        _alertPage.DismissAlert();
    }

    [Given(@"I want to get an open alert's message")]
    public void GivenIWantToGetAnOpenAlertsMessage()
    {
        _alertPage.GetDialogMessage();
    }

    [Given(@"I want to confirm an open prompt alert with ""([^""]*)""")]
    public void GivenIWantToConfirmAnOpenPromptAlertWith(string promptText)
    {
        _alertPage.AcceptPromptAlert(promptText);
    }

    [When(@"I open the simple alert and accept it")]
    public async Task WhenIAcceptTheSimpleAlert()
    {
        await _alertPage.OpenSimpleAlert();
    }

    [When(@"I open the confirm alert and dismiss it")]
    public async Task WhenIDismissTheConfirmAlert()
    {
        await _alertPage.OpenConfirmAlert();
    }

    [When(@"I open and confirm the prompt alert")]
    public async Task WhenIConfirmThePromptAlert()
    {
        await _alertPage.OpenPromptAlert();
    }

    [When(@"I open the modern alert and close it")]
    public async Task WhenICloseTheModernAlert()
    {
        await _alertPage.OpenModernAlert();
        await _alertPage.CloseModernAlert();
    }

    [Then(@"the alert should be closed")]
    public async Task ThenTheAlertShouldBeClosed()
    {
        await _alertPage.NavigateToWorkspaces();
        string pageTitle = await _alertPage.PageTitle();
        pageTitle.Should().Be("LetCode - Testing Hub");
    }

    [Then(@"I should have the alert text")]
    public void ThenIShouldHaveTheAlertText()
    {
        _alertPage.DialogMsg.Should().Be("Are you happy with LetCode?");
    }
}