using Microsoft.Playwright;

namespace UIAutomationDemo.Specs.Pages.Playwright;

public class DropdownPage : BasePage
{
    private static string Url => "https://letcode.in/dropdowns";

    private static string FruitsDropdown => "#fruits";
    private static string SuperheroesMultiSelect => "#superheros";
    private static string ProgrammingLanguageDropdown => "#lang";
    private static string ProgrammingLanguageOptions => "#lang option";
    private static string CountryDropdown => "#country";

    public DropdownPage(IPage page) : base(page, Url) { }

    public async Task SelectFruitByVisibleText(string fruit) => 
        await _page.SelectOptionAsync(FruitsDropdown, new SelectOptionValue { Label = fruit });

    public async Task<string> GetSelectedFruit() => await _page.EvalOnSelectorAsync<string>(FruitsDropdown, "el => el.options[el.selectedIndex].text");

    public async Task SelectSuperheroes(params string[] superheroes) =>
        await _page.SelectOptionAsync(SuperheroesMultiSelect, superheroes);

    public async Task<string[]> GetSelectedSuperheroes() => 
        await _page.EvalOnSelectorAsync<string[]>(SuperheroesMultiSelect, "el => Array.from(el.selectedOptions).map(({ value }) => value)");

    public async Task SelectLastProgrammingLanguage()
    {
        int languagesInDropdown = await _page.Locator(ProgrammingLanguageOptions).CountAsync();
        int lastLanguageIndex = languagesInDropdown - 1;
        await _page.SelectOptionAsync(ProgrammingLanguageDropdown, new SelectOptionValue 
        { 
            Index = lastLanguageIndex
        });
    }

    public async Task<string> GetSelectedProgrammingLanguage() => 
        await _page.EvalOnSelectorAsync<string>(ProgrammingLanguageDropdown, "el => el.options[el.selectedIndex].text");

    public async Task<IReadOnlyList<string>> GetAllProgrammingLanguagesFromDropdown()
    {
        var languageOptions = _page.Locator(ProgrammingLanguageOptions);
        return await languageOptions.AllTextContentsAsync();
    }

    public async Task SelectCountryByValue(string country) =>
      await _page.SelectOptionAsync(CountryDropdown, new SelectOptionValue { Value = country });

    public async Task<string> GetSelectedCountry() =>
        await _page.EvalOnSelectorAsync<string>(CountryDropdown, "el => el.options[el.selectedIndex].text");
}