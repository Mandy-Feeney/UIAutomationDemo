using UIAutomationDemo.Specs.Pages.Playwright;

namespace UIAutomationDemo.Specs.Steps.Playwright;

[Binding]
[Scope(Tag = "playwright")]
public class ElementsSteps
{
    private readonly ElementsPage _elementsPage;

    public ElementsSteps(ElementsPage elementsPage) => _elementsPage = elementsPage;

    [Given(@"I am on the Elements page")]
    public async Task GivenIAmOnTheElementsPage()
    {
        await _elementsPage.Goto();
    }

    [When(@"I search for the Git user ""([^""]*)""")]
    public async Task WhenISearchForTheGitUser(string gitUsername)
    {
        await _elementsPage.SearchGitUsername(gitUsername);
    }

    [Then(@"I should see the Git user ""([^""]*)"" can be found")]
    public async Task ThenIShouldSeeTheGitUserCanBeFound(string gitUsername)
    {
        bool profileCanBeFound = await _elementsPage.HasGitProfileBeenFound();
        profileCanBeFound.Should().BeTrue();

        string foundGitUsername = await _elementsPage.GetGitUsername();
        foundGitUsername.Should().Be(gitUsername);
    }

    [Then(@"I should see a profile image is displayed")]
    public async Task ThenIShouldSeeAProfileImageIsDisplayed()
    {
        bool imageIsDisplayed = await _elementsPage.HasGitProfileImage();
        imageIsDisplayed.Should().BeTrue();
    }

    [Then(@"I should see the number of public repos")]
    public async Task ThenIShouldSeeTheNumberOfPublicRepos()
    {
        int gitPublicRepos = int.Parse(await _elementsPage.GetGitPublicRepos());
        gitPublicRepos.Should().BeGreaterThan(0);
    }
}