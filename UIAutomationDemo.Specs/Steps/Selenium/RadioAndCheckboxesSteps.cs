using UIAutomationDemo.Specs.Pages.Selenium;

namespace UIAutomationDemo.Specs.Steps.Selenium;

[Binding]
[Scope(Tag = "selenium")]
public class RadioAndCheckboxesSteps
{
    private readonly RadioAndCheckboxesPage _radioAndCheckboxesPage;

    public RadioAndCheckboxesSteps(RadioAndCheckboxesPage radioAndCheckboxesPage) => _radioAndCheckboxesPage = radioAndCheckboxesPage;

    [Given(@"I am on the Radio and Checkboxes page")]
    public void GivenIAmOnTheRadioAndCheckboxesPage()
    {
        _radioAndCheckboxesPage.Goto();
    }

    [When(@"I select the radio button for ""(Yes|No)""")]
    public void WhenISelectTheRadioButtonFor(string radioOption)
    {
        _radioAndCheckboxesPage.SelectRadioOption(radioOption);
    }

    [Then(@"I should see ""(Yes|No)"" is selected")]
    public void ThenIShouldSeeOptionIsSelected(string radioOption)
    {
        bool isSelected = _radioAndCheckboxesPage.IsRadioOptionSelected(radioOption);
        isSelected.Should().BeTrue();
    }

    [Then(@"I should see ""(Yes|No)"" is not selected")]
    public void ThenIShouldSeeOptionIsNotSelected(string radioOption)
    {
        bool isSelected = _radioAndCheckboxesPage.IsRadioOptionSelected(radioOption);
        isSelected.Should().BeFalse();
    }

    [Then(@"the radio button for ""([^""]*)"" is disabled")]
    public void ThenTheRadioButtonForIsDisabled(string radioOption)
    {
        bool isDisabled = _radioAndCheckboxesPage.IsRadioOptionDisabled(radioOption);
        isDisabled.Should().BeTrue();
    }

    [When(@"I select the checkbox for accepting the T&C")]
    public void WhenISelectTheCheckboxForAcceptingTheTC()
    {
        _radioAndCheckboxesPage.CheckTermsAndConditions();
    }

    [Then(@"I should see the T&C checkbox is selected")]
    public void ThenIShouldSeeTheTCCheckboxIsSelected()
    {
        bool isSelected = _radioAndCheckboxesPage.IsTermsAndConditionsChecked();
        isSelected.Should().BeTrue();
    }
}