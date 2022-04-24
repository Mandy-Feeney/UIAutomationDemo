@playwright
Feature: Drag and Drop
	Performing a drag and drop operation in a web application.

Scenario: Drag and dropping an element
	Given I am on the Drag and Drop page
	When I drag an element to the target
	Then I should see the element has been dragged on top of the target