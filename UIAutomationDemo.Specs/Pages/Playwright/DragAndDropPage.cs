using Microsoft.Playwright;

namespace UIAutomationDemo.Specs.Pages.Playwright;

public class DragAndDropPage : BasePage
{
    private static string Url => "https://letcode.in/dropable";

    private static string DraggableBox => "#draggable";
    private static string DroppableBox => "#droppable";

    public DragAndDropPage(IPage page) : base(page, Url) { }

    public async Task DragBoxToTarget()
    {
        await _page.DragAndDropAsync(DraggableBox, DroppableBox);
    }

    public async Task<bool> IsSourceBoxOnTarget()
    {
        var draggableBox = await _page.Locator(DraggableBox).BoundingBoxAsync();
        var droppableBox = await _page.Locator(DroppableBox).BoundingBoxAsync();

        float? startX = droppableBox?.X;
        float? endX = droppableBox?.X + droppableBox?.Width;

        float? startY = droppableBox?.Y;
        float? endY = droppableBox?.Y + droppableBox?.Height;

        return (draggableBox?.X >= startX) && (draggableBox?.X <= endX) && (draggableBox?.Y >= startY) && (draggableBox?.Y <= endY);
    }
}