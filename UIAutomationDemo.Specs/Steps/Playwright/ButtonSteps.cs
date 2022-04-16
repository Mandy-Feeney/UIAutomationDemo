using FluentAssertions.Execution;
using UIAutomationDemo.Specs.Pages.Playwright;

namespace UIAutomationDemo.Specs.Steps.Playwright;

[Binding]
[Scope(Tag = "playwright")]
public class ButtonSteps
{
    private readonly ButtonPage _buttonPage;

    public ButtonSteps(ButtonPage buttonPage) => _buttonPage = buttonPage;

    [Given(@"I am on the Button page")]
    public async Task GivenIAmOnTheButtonPage()
    {
        await _buttonPage.Goto();
    }

    [When(@"I click the Goto Home button")]
    public async Task WhenIClickTheGotoHomeButton()
    {
        await _buttonPage.ClickHomeButton();
    }

    [Then(@"I should see I have navigated to the homepage")]
    public async Task ThenIShouldSeeIHaveNavigatedToTheHomepage()
    {
        string actualTitle = await _buttonPage.PageTitle();
        actualTitle.Should().Be("LetCode with Koushik");
    }

    [Then(@"I should be able to see the X and Y coordinates of the button")]
    public async Task ThenIShouldBeAbleToSeeTheXAndYCoordinatesOfTheButton()
    {
        (float? x, float? y) = await _buttonPage.GetCoordinatesOfButton();

        using (new AssertionScope())
        {
            x.Should().NotBeNull();
            y.Should().NotBeNull();
        };
    }

    [Then(@"I should be able to see the colour of the button")]
    public async Task ThenIShouldBeAbleToSeeTheColourOfTheButton()
    {
        var buttonColour = await _buttonPage.GetColourOfButton();
        buttonColour.Should().Be("rgb(138, 77, 118)");
    }

    [Then(@"I should be able to see the height and width of the button")]
    public async Task ThenIShouldBeAbleToSeeTheHeightAndWidthOfTheButton()
    {
        (float? width, float? height) = await _buttonPage.GetSizeOfButton();

        using (new AssertionScope()) 
        {
            width.Should().Be(176.21875f);
            height.Should().Be(40f);
        };
    }

    [Then(@"I should see the button is disabled")]
    public async Task ThenIShouldSeeTheButtonIsDisabled()
    {
        bool actualState = await _buttonPage.IsButtonDisabled();
        actualState.Should().BeTrue();
    }

    [When(@"I click and hold the button for (.*) seconds")]
    public async Task WhenIClickAndHoldTheButtonForSeconds(int holdClickInSeconds)
    {
        await _buttonPage.LongClickButton(holdClickInSeconds);
    }

    [Then(@"I should see the button text has changed")]
    public async Task ThenIShouldSeeTheButtonTextHasChanged()
    {
        string actualButtonText = await _buttonPage.GetLongClickButtonText();
        actualButtonText.Should().Be("Button has been long pressed");
    }
}