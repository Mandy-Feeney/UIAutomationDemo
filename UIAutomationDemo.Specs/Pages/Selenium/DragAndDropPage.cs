using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UIAutomationDemo.Specs.Pages.Selenium;

public class DragAndDropPage : BasePage
{
    private static string Url => "https://letcode.in/dropable";

    private static By DraggableBox => By.Id("draggable");
    private static By DroppableBox => By.Id("droppable");

    public DragAndDropPage(IWebDriver driver) : base(driver, Url) { }

    public void DragBoxToTarget()
    {
        Actions action = new Actions(_driver);
        IWebElement sourceBox = _driver.FindElement(DraggableBox);
        IWebElement targetBox = _driver.FindElement(DroppableBox);

        action.DragAndDrop(sourceBox, targetBox).Build().Perform();
    }

    public bool IsSourceBoxOnTarget()
    {
        var draggableBox = _driver.FindElement(DraggableBox);
        var droppableBox = _driver.FindElement(DroppableBox);

        float? startX = droppableBox.Location.X;
        float? endX = droppableBox.Location.X + droppableBox.Size.Width;

        float? startY = droppableBox.Location.Y;
        float? endY = droppableBox.Location.Y + droppableBox.Size.Height;

        return (draggableBox.Location.X >= startX) && (draggableBox.Location.X <= endX) && 
               (draggableBox.Location.Y >= startY) && (draggableBox.Location.Y <= endY);
    }
}