using UIAutomationDemo.Specs.Pages.Selenium;

namespace UIAutomationDemo.Specs.Steps.Selenium;

[Binding]
[Scope(Tag = "selenium")]
public class ElementsSteps
{
    private readonly ElementsPage _elementsPage;

    public ElementsSteps(ElementsPage elementsPage) => _elementsPage = elementsPage;

    [Given(@"I am on the Elements page")]
    public void GivenIAmOnTheElementsPage()
    {
        _elementsPage.Goto();
    }

    [When(@"I search for the Git user ""([^""]*)""")]
    public void WhenISearchForTheGitUser(string gitUsername)
    {
        _elementsPage.SearchGitUsername(gitUsername);
    }

    [Then(@"I should see the Git user ""([^""]*)"" can be found")]
    public void ThenIShouldSeeTheGitUserCanBeFound(string gitUsername)
    {
        bool profileCanBeFound = _elementsPage.HasGitProfileBeenFound();
        profileCanBeFound.Should().BeTrue();

        string foundGitUsername = _elementsPage.GetGitUsername();
        foundGitUsername.Should().Be(gitUsername);
    }

    [Then(@"I should see a profile image is displayed")]
    public void ThenIShouldSeeAProfileImageIsDisplayed()
    {
        bool imageIsDisplayed = _elementsPage.HasGitProfileImage();
        imageIsDisplayed.Should().BeTrue();
    }

    [Then(@"I should see the number of public repos")]
    public void ThenIShouldSeeTheNumberOfPublicRepos()
    {
        int gitPublicRepos = int.Parse(_elementsPage.GetGitPublicRepos());
        gitPublicRepos.Should().BeGreaterThan(0);
    }
}