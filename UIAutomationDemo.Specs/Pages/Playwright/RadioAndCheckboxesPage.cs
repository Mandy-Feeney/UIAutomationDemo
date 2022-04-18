using Microsoft.Playwright;

namespace UIAutomationDemo.Specs.Pages.Playwright;

public class RadioAndCheckboxesPage : BasePage
{
    private static string Url => "https://letcode.in/radio";
    private static string TermsAndConditionsCheckbox => "(//input[@type='checkbox'])[2]";

    public RadioAndCheckboxesPage(IPage page) : base(page, Url) { }

    public async Task SelectRadioOption(string radioOptionId) => await _page.CheckAsync($"#{radioOptionId.ToLower()}");

    public async Task CheckTermsAndConditions() => await _page.CheckAsync(TermsAndConditionsCheckbox);

    public async Task<bool> IsRadioOptionSelected(string radioOptionId) => await _page.IsCheckedAsync($"#{radioOptionId.ToLower()}");

    public async Task<bool> IsRadioOptionDisabled(string radioOptionId) => await _page.IsDisabledAsync($"#{radioOptionId.ToLower()}");

    public async Task<bool> IsTermsAndConditionsChecked() => await _page.IsCheckedAsync(TermsAndConditionsCheckbox);
}