using UIAutomationDemo.Specs.Pages.Playwright;

namespace UIAutomationDemo.Specs.Steps.Playwright;

[Binding]
[Scope(Tag = "playwright")]
public class DropdownSteps
{
    private readonly DropdownPage _dropdownPage;
    private readonly IDictionary<string, string> _superheroes = new Dictionary<string, string>();
    private IReadOnlyList<string>? _allProgrammingLanguages;

    public DropdownSteps(DropdownPage dropdownPage) => _dropdownPage = dropdownPage;

    [Given(@"I am on the Dropdown page")]
    public async Task GivenIAmOnTheDropdownPage()
    {
        await _dropdownPage.Goto();
    }

    [When(@"I select ""([^""]*)"" by its visible text from the fruit dropdown")]
    public async Task WhenISelectAFruitByItsVisibleTextFromTheFruitDropdown(string fruit)
    {
        await _dropdownPage.SelectFruitByVisibleText(fruit);
    }

    [Then(@"I should see ""([^""]*)"" is the selected fruit")]
    public async Task ThenIShouldSeeIsTheSelectedFruit(string fruit)
    {
        string selectedFruit = await _dropdownPage.GetSelectedFruit();
        selectedFruit.Should().Be(fruit);
    }

    [Given(@"my favourite superheroes are:")]
    public void GivenMyFavouriteSuperheroesAre(Table superheroes)
    {
        foreach(var row in superheroes.Rows)
        {
            _superheroes.Add(row[0], row[1]);
        }
    }

    [When(@"I select each of these options from the superhero dropdown")]
    public async Task WhenISelectEachOfTheseOptionsFromTheSuperheroDropdown()
    {
        await _dropdownPage.SelectSuperheroes(_superheroes.Values.ToArray());
    }

    [Then(@"I should see all of my favourite superheroes are selected")]
    public async Task ThenIShouldSeeAllOfMyFavouriteSuperheroesAreSelected()
    {
        string[] selectedSuperheroes = await _dropdownPage.GetSelectedSuperheroes();
        selectedSuperheroes.Should().BeEquivalentTo(_superheroes.Values);
    }

    [When(@"I select the last programming language from the dropdown")]
    public async Task WhenISelectTheLastProgrammingLanguageFromTheDropdown()
    {
        await _dropdownPage.SelectLastProgrammingLanguage();
    }

    [Then(@"I should see ""([^""]*)"" is the selected programming language")]
    public async Task ThenIShouldSeeIsTheSelectedProgrammingLanguage(string programmingLanguage)
    {
        string selectedProgrammingLanguage = await _dropdownPage.GetSelectedProgrammingLanguage();
        selectedProgrammingLanguage.Should().Be(programmingLanguage);
    }

    [When(@"I get all the programming languages from the dropdown")]
    public async Task WhenIGetAllTheProgrammingLanguagesFromTheDropdown()
    {
        _allProgrammingLanguages = await _dropdownPage.GetAllProgrammingLanguagesFromDropdown();
    }

    [Then(@"I should see all programming languages from the dropdown")]
    public void ThenIShouldSeeAllProgrammingLanguagesFromTheDropdown()
    {
        _allProgrammingLanguages.Should().BeEquivalentTo("JavaScript", "Java", "Python", "Swift", "C#");
    }

    [When(@"I select ""([^""]*)"" by its value from the country dropdown")]
    public async Task WhenISelectACountryByItsValueFromTheCountryDropdown(string country)
    {
        await _dropdownPage.SelectCountryByValue(country);
    }

    [Then(@"I should see ""([^""]*)"" is the selected country")]
    public async Task ThenIShouldSeeIsTheSelectedCountry(string country)
    {
        string selectedCountry = await _dropdownPage.GetSelectedCountry();
        selectedCountry.Should().Be(country);
    }
}