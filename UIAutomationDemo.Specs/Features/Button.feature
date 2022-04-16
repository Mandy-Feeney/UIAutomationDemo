@playwright
Feature: Button
	Interacting with Buttons in a web application.

Background:
	Given I am on the Button page

Scenario: Clicking a button
	When I click the Goto Home button
	Then I should see I have navigated to the homepage

Scenario: Getting the X and Y coordinates of a Button
	Then I should be able to see the X and Y coordinates of the button

Scenario: Getting the colour of a Button
	Then I should be able to see the colour of the button

Scenario: Getting the size of a Button
	Then I should be able to see the height and width of the button

Scenario: Getting disabled state of a Button
	Then I should see the button is disabled

Scenario: Performing a long click on a Button
	When I click and hold the button for 2 seconds
	Then I should see the button text has changed