using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UIAutomationDemo.Specs.Pages.Selenium;

public class DropdownPage : BasePage
{
    private static string Url => "https://letcode.in/dropdowns";

    private static By FruitsDropdown => By.Id("fruits");
    private static By SuperheroesMultiSelect => By.Id("superheros");
    private static By ProgrammingLanguageDropdown => By.Id("lang");
    private static By CountryDropdown => By.Id("country");

    public DropdownPage(IWebDriver driver) : base(driver, Url) { }

    public void SelectFruitByVisibleText(string fruit)
    {
        SelectElement fruitsSelect = new(_driver.FindElement(FruitsDropdown));
        fruitsSelect.SelectByText(fruit);
    }

    public string GetSelectedFruit()
    {
        SelectElement fruitsSelect = new(_driver.FindElement(FruitsDropdown));
        return fruitsSelect.SelectedOption.Text;
    }

    public void SelectSuperheroes(params string[] superheroes)
    {
        SelectElement superheroesSelect = new(_driver.FindElement(SuperheroesMultiSelect));

        foreach(var superhero in superheroes)
            superheroesSelect.SelectByValue(superhero);
    }

    public string[] GetSelectedSuperheroes()
    {
        SelectElement superheroesSelect = new(_driver.FindElement(SuperheroesMultiSelect));
        return superheroesSelect.AllSelectedOptions.Select(s => s.GetAttribute("value")).ToArray();
    }

    public void SelectLastProgrammingLanguage()
    {
        SelectElement programmingLanguagesSelect = new(_driver.FindElement(ProgrammingLanguageDropdown));
        int languagesInDropdown = programmingLanguagesSelect.Options.Count;
        int lastLanguageIndex = languagesInDropdown - 1;
        programmingLanguagesSelect.SelectByIndex(lastLanguageIndex);
    }

    public string GetSelectedProgrammingLanguage()
    {
        SelectElement programmingLanguagesSelect = new(_driver.FindElement(ProgrammingLanguageDropdown));
        return programmingLanguagesSelect.SelectedOption.Text; 
    }

    public IReadOnlyList<string> GetAllProgrammingLanguagesFromDropdown()
    {
        SelectElement programmingLanguagesSelect = new(_driver.FindElement(ProgrammingLanguageDropdown));
        return programmingLanguagesSelect.Options.Select(o => o.Text).ToList();
    }

    public void SelectCountryByValue(string country)
    {
        SelectElement countrySelect = new(_driver.FindElement(CountryDropdown));
        countrySelect.SelectByValue(country);
    }

    public string GetSelectedCountry()
    {
        SelectElement countrySelect = new(_driver.FindElement(CountryDropdown));
        return countrySelect.SelectedOption.Text;
    }
}