using UIAutomationDemo.Specs.Pages.Playwright;

namespace UIAutomationDemo.Specs.Steps.Playwright;

[Binding]
[Scope(Tag = "playwright")]
public class InputFieldSteps
{
    private readonly InputFieldPage _inputFieldPage;

    public InputFieldSteps(InputFieldPage inputFieldPage) => _inputFieldPage = inputFieldPage;

    [Given(@"I am on the Input Field page")]
    public async Task GivenIAmOnTheInputFieldPage()
    {
        await _inputFieldPage.Goto();
    }

    [When(@"I enter the text ""([^""]*)""")]
    public async Task WhenIEnterTheText(string text)
    {
        await _inputFieldPage.EnterFullName(text);
    }

    [When(@"I append the text ""([^""]*)""")]
    public async Task WhenIAppendTheText(string text)
    {
        await _inputFieldPage.AppendText(text);
    }

    [When(@"I clear the input field")]
    public async Task WhenIClearTheInputField()
    {
        await _inputFieldPage.ClearTextInField();
    }

    [Then(@"I should see ""([^""]*)"" has been entered into the input field")]
    public async Task ThenIShouldSeeHasBeenEnteredIntoTheInputField(string text)
    {
        string actualText = await _inputFieldPage.GetEnteredFullname();
        actualText.Should().Be(text);
    }

    [Then(@"I should see ""([^""]*)"" appended to the input field")]
    public async Task ThenIShouldSeeTheAppendedToTheInputField(string text)
    {
        const string alreadyFilledInText = "I am good";
        string actualText = await _inputFieldPage.GetEnteredAppendedText();
        actualText.Should().Be($"{alreadyFilledInText}{text}");
    }

    [Then(@"I should see the input field is empty")]
    public async Task ThenIShouldSeeTheInputFieldIsEmpty()
    {
        string actualText = await _inputFieldPage.GetClearedFieldText();
        actualText.Should().BeEmpty();
    }

    [Then(@"I should see the input field is disabled")]
    public async Task ThenIShouldSeeTheInputFieldIsDisabled()
    {
        bool actualState = await _inputFieldPage.IsFieldDisabled();
        actualState.Should().BeTrue();
    }

    [Then(@"I should see the input field is readonly")]
    public async Task ThenIShouldSeeTheInputFieldIsReadonly()
    {
        bool actualState = await _inputFieldPage.IsFieldEditable();
        actualState.Should().BeFalse();
    }
}
