@playwright
Feature: Input Field
	Interacting with Input fields in a web application.

Background:
	Given I am on the Input Field page

Scenario: Entering text into an Input Field
	When I enter the text "Homer Simpson"
	Then I should see "Homer Simpson" has been entered into the input field

Scenario: Appending text to an Input Field
	When I append the text "Test"
	Then I should see "Test" appended to the input field

Scenario: Clearing text in an Input Field
	When I clear the input field
	Then I should see the input field is empty

Scenario: Getting disabled state of an Input Field
	Then I should see the input field is disabled

Scenario: Getting editable state of an Input Field
	Then I should see the input field is readonly