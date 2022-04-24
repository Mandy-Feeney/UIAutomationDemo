using UIAutomationDemo.Specs.Pages.Selenium;

namespace UIAutomationDemo.Specs.Steps.Selenium;

[Binding]
[Scope(Tag = "selenium")]
public class DragAndDropSteps
{
    private readonly DragAndDropPage _dragAndDropPage;

    public DragAndDropSteps(DragAndDropPage dragAndDropPage) => _dragAndDropPage = dragAndDropPage;

    [Given(@"I am on the Drag and Drop page")]
    public void GivenIAmOnTheDragAndDropPage()
    {
        _dragAndDropPage.Goto();
    }

    [When(@"I drag an element to the target")]
    public void WhenIDragAnElementToTheTarget()
    {
        _dragAndDropPage.DragBoxToTarget();
    }

    [Then(@"I should see the element has been dragged on top of the target")]
    public void ThenIShouldSeeTheElementHasBeenDraggedOnTopOfTheTarget()
    {
        bool hasBeenMoved = _dragAndDropPage.IsSourceBoxOnTarget();
        hasBeenMoved.Should().BeTrue();
    }
}