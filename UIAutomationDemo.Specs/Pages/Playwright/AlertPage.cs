using Microsoft.Playwright;

namespace UIAutomationDemo.Specs.Pages.Playwright;

public class AlertPage : BasePage
{
    private static string Url => "https://letcode.in/alert";

    private static string SimpleAlertButton => "#accept";
    private static string ConfirmAlertButton => "#confirm";
    private static string PromptAlertButton => "#prompt";
    private static string ModernAlertButton => "#modern";
    private static string ModernAlertCloseButton => ".modal-close";

    public string DialogMsg { get; set; } = string.Empty;

    public AlertPage(IPage page) : base(page, Url) { }

    public async Task OpenSimpleAlert() => await _page.ClickAsync(SimpleAlertButton);

    public async Task OpenConfirmAlert() =>  await _page.ClickAsync(ConfirmAlertButton);

    public async Task OpenPromptAlert() => await _page.ClickAsync(PromptAlertButton);

    public async Task OpenModernAlert() => await _page.ClickAsync(ModernAlertButton);

    public async Task CloseModernAlert() => await _page.ClickAsync(ModernAlertCloseButton);

    public void AcceptAlert() => _page.Dialog += (_, dialog) => dialog.AcceptAsync();

    public void AcceptPromptAlert(string promptText) => _page.Dialog += (_, dialog) => dialog.AcceptAsync(promptText);

    public void DismissAlert() => _page.Dialog += (_, dialog) => dialog.DismissAsync();

    public void GetDialogMessage()
    {
        _page.Dialog += async (_, dialog) =>
        {
            DialogMsg = dialog.Message;
            await dialog.DismissAsync();
        };
    }
}