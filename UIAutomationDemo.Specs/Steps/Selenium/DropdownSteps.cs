using UIAutomationDemo.Specs.Pages.Selenium;

namespace UIAutomationDemo.Specs.Steps.Selenium;

[Binding]
[Scope(Tag = "selenium")]
public class DropdownSteps
{
    private readonly DropdownPage _dropdownPage;
    private readonly IDictionary<string, string> _superheroes = new Dictionary<string, string>();
    private IReadOnlyList<string>? _allProgrammingLanguages;

    public DropdownSteps(DropdownPage dropdownPage) => _dropdownPage = dropdownPage;

    [Given(@"I am on the Dropdown page")]
    public void GivenIAmOnTheDropdownPage()
    {
        _dropdownPage.Goto();
    }

    [When(@"I select ""([^""]*)"" by its visible text from the fruit dropdown")]
    public void WhenISelectAFruitByItsVisibleTextFromTheFruitDropdown(string fruit)
    {
        _dropdownPage.SelectFruitByVisibleText(fruit);
    }

    [Then(@"I should see ""([^""]*)"" is the selected fruit")]
    public void ThenIShouldSeeIsTheSelectedFruit(string fruit)
    {
        string selectedFruit = _dropdownPage.GetSelectedFruit();
        selectedFruit.Should().Be(fruit);
    }

    [Given(@"my favourite superheroes are:")]
    public void GivenMyFavouriteSuperheroesAre(Table superheroes)
    {
        foreach (var row in superheroes.Rows)
        {
            _superheroes.Add(row[0], row[1]);
        }
    }

    [When(@"I select each of these options from the superhero dropdown")]
    public void WhenISelectEachOfTheseOptionsFromTheSuperheroDropdown()
    {
        _dropdownPage.SelectSuperheroes(_superheroes.Values.ToArray());
    }

    [Then(@"I should see all of my favourite superheroes are selected")]
    public void ThenIShouldSeeAllOfMyFavouriteSuperheroesAreSelected()
    {
        string[] selectedSuperheroes = _dropdownPage.GetSelectedSuperheroes();
        selectedSuperheroes.Should().BeEquivalentTo(_superheroes.Values);
    }

    [When(@"I select the last programming language from the dropdown")]
    public void WhenISelectTheLastProgrammingLanguageFromTheDropdown()
    {
        _dropdownPage.SelectLastProgrammingLanguage();
    }

    [Then(@"I should see ""([^""]*)"" is the selected programming language")]
    public void ThenIShouldSeeIsTheSelectedProgrammingLanguage(string programmingLanguage)
    {
        string selectedProgrammingLanguage = _dropdownPage.GetSelectedProgrammingLanguage();
        selectedProgrammingLanguage.Should().Be(programmingLanguage);
    }

    [When(@"I get all the programming languages from the dropdown")]
    public void WhenIGetAllTheProgrammingLanguagesFromTheDropdown()
    {
        _allProgrammingLanguages = _dropdownPage.GetAllProgrammingLanguagesFromDropdown();
    }

    [Then(@"I should see all programming languages from the dropdown")]
    public void ThenIShouldSeeAllProgrammingLanguagesFromTheDropdown()
    {
        _allProgrammingLanguages.Should().BeEquivalentTo("JavaScript", "Java", "Python", "Swift", "C#");
    }

    [When(@"I select ""([^""]*)"" by its value from the country dropdown")]
    public void WhenISelectACountryByItsValueFromTheCountryDropdown(string country)
    {
        _dropdownPage.SelectCountryByValue(country);
    }

    [Then(@"I should see ""([^""]*)"" is the selected country")]
    public void ThenIShouldSeeIsTheSelectedCountry(string country)
    {
        string selectedCountry = _dropdownPage.GetSelectedCountry();
        selectedCountry.Should().Be(country);
    }
}