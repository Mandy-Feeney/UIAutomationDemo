using UIAutomationDemo.Specs.Pages.Playwright;

namespace UIAutomationDemo.Specs.Steps.Playwright;

[Binding]
[Scope(Tag = "playwright")]
public class RadioAndCheckboxesSteps
{
    private readonly RadioAndCheckboxesPage _radioAndCheckboxesPage;

    public RadioAndCheckboxesSteps(RadioAndCheckboxesPage radioAndCheckboxesPage) => _radioAndCheckboxesPage = radioAndCheckboxesPage;

    [Given(@"I am on the Radio and Checkboxes page")]
    public async Task GivenIAmOnTheRadioAndCheckboxesPage()
    {
        await _radioAndCheckboxesPage.Goto();
    }

    [When(@"I select the radio button for ""(Yes|No)""")]
    public async Task WhenISelectTheRadioButtonFor(string radioOption)
    {
        await _radioAndCheckboxesPage.SelectRadioOption(radioOption);
    }

    [Then(@"I should see ""(Yes|No)"" is selected")]
    public async Task ThenIShouldSeeOptionIsSelected(string radioOption)
    {
        bool isSelected = await _radioAndCheckboxesPage.IsRadioOptionSelected(radioOption);
        isSelected.Should().BeTrue();
    }

    [Then(@"I should see ""(Yes|No)"" is not selected")]
    public async Task ThenIShouldSeeOptionIsNotSelected(string radioOption)
    {
        bool isSelected = await _radioAndCheckboxesPage.IsRadioOptionSelected(radioOption);
        isSelected.Should().BeFalse();
    }

    [Then(@"the radio button for ""([^""]*)"" is disabled")]
    public async Task ThenTheRadioButtonForIsDisabled(string radioOption)
    {
        bool isDisabled = await _radioAndCheckboxesPage.IsRadioOptionDisabled(radioOption);
        isDisabled.Should().BeTrue();
    }

    [When(@"I select the checkbox for accepting the T&C")]
    public async Task WhenISelectTheCheckboxForAcceptingTheTC()
    {
        await _radioAndCheckboxesPage.CheckTermsAndConditions();
    }

    [Then(@"I should see the T&C checkbox is selected")]
    public async Task ThenIShouldSeeTheTCCheckboxIsSelected()
    {
        bool isSelected = await _radioAndCheckboxesPage.IsTermsAndConditionsChecked();
        isSelected.Should().BeTrue();
    }
}