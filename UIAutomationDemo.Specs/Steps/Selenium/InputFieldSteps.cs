using UIAutomationDemo.Specs.Pages.Selenium;

namespace UIAutomationDemo.Specs.Steps.Selenium;

[Binding]
[Scope(Tag = "selenium")]
public class InputFieldSteps
{
    private readonly InputFieldPage _inputFieldPage;

    public InputFieldSteps(InputFieldPage inputFieldPage) => _inputFieldPage = inputFieldPage;

    [Given(@"I am on the Input Field page")]
    public void GivenIAmOnTheInputFieldPage()
    {
        _inputFieldPage.Goto();
    }

    [When(@"I enter the text ""([^""]*)""")]
    public void WhenIEnterTheText(string text)
    {
        _inputFieldPage.EnterFullName(text);
    }

    [When(@"I append the text ""([^""]*)""")]
    public void WhenIAppendTheText(string text)
    {
        _inputFieldPage.AppendText(text);
    }

    [When(@"I clear the input field")]
    public void WhenIClearTheInputField()
    {
        _inputFieldPage.ClearTextInField();
    }

    [Then(@"I should see ""([^""]*)"" has been entered into the input field")]
    public void ThenIShouldSeeHasBeenEnteredIntoTheInputField(string text)
    {
        string actualText = _inputFieldPage.GetEnteredFullname();
        actualText.Should().Be(text);
    }

    [Then(@"I should see ""([^""]*)"" appended to the input field")]
    public void ThenIShouldSeeTheAppendedToTheInputField(string text)
    {
        const string alreadyFilledInText = "I am good";
        string actualText = _inputFieldPage.GetEnteredAppendedText();
        actualText.Should().Be($"{alreadyFilledInText}{text}");
    }

    [Then(@"I should see the input field is empty")]
    public void ThenIShouldSeeTheInputFieldIsEmpty()
    {
        string actualText = _inputFieldPage.GetClearedFieldText();
        actualText.Should().BeEmpty();
    }

    [Then(@"I should see the input field is disabled")]
    public void ThenIShouldSeeTheInputFieldIsDisabled()
    {
        bool actualState = _inputFieldPage.IsFieldDisabled();
        actualState.Should().BeTrue();
    }

    [Then(@"I should see the input field is readonly")]
    public void ThenIShouldSeeTheInputFieldIsReadonly()
    {
        bool actualState = _inputFieldPage.IsFieldEditable();
        actualState.Should().BeFalse();
    }
}