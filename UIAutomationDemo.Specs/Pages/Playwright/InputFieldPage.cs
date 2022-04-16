using Microsoft.Playwright;

namespace UIAutomationDemo.Specs.Pages.Playwright;

public class InputFieldPage : BasePage
{
    private static string Url => "https://letcode.in/edit";

    private static string FullNameField => "#fullName";
    private static string AppendTextField => "#join";
    private static string ClearField => "#clearMe";
    private static string DisabledField => "#noEdit";
    private static string ReadonlyField => "#dontwrite";

    public InputFieldPage(IPage page) : base(page, Url) { }

    public async Task EnterFullName(string text) => await _page.FillAsync(FullNameField, text);

    public async Task AppendText(string text)
    {
        await _page.PressAsync(AppendTextField, "End");
        await _page.TypeAsync(AppendTextField, text);
    }

    public async Task ClearTextInField() => await _page.FillAsync(ClearField, "");

    public async Task<string> GetEnteredFullname() => await _page.InputValueAsync(FullNameField);

    public async Task<string> GetEnteredAppendedText() => await _page.InputValueAsync(AppendTextField);

    public async Task<string> GetClearedFieldText() => await _page.InputValueAsync(ClearField);

    public async Task<bool> IsFieldDisabled() => await _page.IsDisabledAsync(DisabledField);

    public async Task<bool> IsFieldEditable() => await _page.IsEditableAsync(ReadonlyField);
}
