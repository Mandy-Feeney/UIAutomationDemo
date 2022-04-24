using UIAutomationDemo.Specs.Pages.Playwright;

namespace UIAutomationDemo.Specs.Steps.Playwright;

[Binding]
[Scope(Tag = "playwright")]
public class DragAndDropSteps
{
    private readonly DragAndDropPage _dragAndDropPage;

    public DragAndDropSteps(DragAndDropPage dragAndDropPage) => _dragAndDropPage = dragAndDropPage;

    [Given(@"I am on the Drag and Drop page")]
    public async Task GivenIAmOnTheDragAndDropPage()
    {
        await _dragAndDropPage.Goto();
    }

    [When(@"I drag an element to the target")]
    public async Task WhenIDragAnElementToTheTarget()
    {
        await _dragAndDropPage.DragBoxToTarget();
    }

    [Then(@"I should see the element has been dragged on top of the target")]
    public async Task ThenIShouldSeeTheElementHasBeenDraggedOnTopOfTheTarget()
    {
        bool hasBeenMoved = await _dragAndDropPage.IsSourceBoxOnTarget();
        hasBeenMoved.Should().BeTrue();
    }
}