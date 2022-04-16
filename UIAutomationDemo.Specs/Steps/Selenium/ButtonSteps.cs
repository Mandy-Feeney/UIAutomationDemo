using FluentAssertions.Execution;
using UIAutomationDemo.Specs.Pages.Selenium;

namespace UIAutomationDemo.Specs.Steps.Selenium;

[Binding]
[Scope(Tag = "selenium")]
public class ButtonSteps
{
    private readonly ButtonPage _buttonPage;

    public ButtonSteps(ButtonPage buttonPage) => _buttonPage = buttonPage;

    [Given(@"I am on the Button page")]
    public void GivenIAmOnTheButtonPage()
    {
        _buttonPage.Goto();
    }

    [When(@"I click the Goto Home button")]
    public void WhenIClickTheGotoHomeButton()
    {
        _buttonPage.ClickHomeButton();
    }

    [Then(@"I should see I have navigated to the homepage")]
    public void ThenIShouldSeeIHaveNavigatedToTheHomepage()
    {
        string actualTitle = _buttonPage.PageTitle();
        actualTitle.Should().Be("LetCode with Koushik");
    }

    [Then(@"I should be able to see the X and Y coordinates of the button")]
    public void ThenIShouldBeAbleToSeeTheXAndYCoordinatesOfTheButton()
    {
        (float? x, float? y) = _buttonPage.GetCoordinatesOfButton();

        using (new AssertionScope())
        {
            x.Should().NotBeNull();
            y.Should().NotBeNull();
        };
    }

    [Then(@"I should be able to see the colour of the button")]
    public void ThenIShouldBeAbleToSeeTheColourOfTheButton()
    {
        var buttonColour = _buttonPage.GetColourOfButton();
        buttonColour.Should().Be("rgba(138, 77, 118, 1)");
    }

    [Then(@"I should be able to see the height and width of the button")]
    public void ThenIShouldBeAbleToSeeTheHeightAndWidthOfTheButton()
    {
        (float? width, float? height) = _buttonPage.GetSizeOfButton();

        using (new AssertionScope())
        {
            width.Should().Be(176f);
            height.Should().Be(40f);
        };
    }

    [Then(@"I should see the button is disabled")]
    public void ThenIShouldSeeTheButtonIsDisabled()
    {
        bool actualState = _buttonPage.IsButtonDisabled();
        actualState.Should().BeTrue();
    }

    [When(@"I click and hold the button for (.*) seconds")]
    public void WhenIClickAndHoldTheButtonForSeconds(int holdClickInSeconds)
    {
        _buttonPage.LongClickButton(holdClickInSeconds);
    }

    [Then(@"I should see the button text has changed")]
    public void ThenIShouldSeeTheButtonTextHasChanged()
    {
        string actualButtonText = _buttonPage.GetLongClickButtonText();
        actualButtonText.Should().Be("Button has been long pressed");
    }
}