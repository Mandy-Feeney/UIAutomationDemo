@playwright
Feature: Radio And Checkboxes
	Interacting with Radio buttons and Checkboxes in a web application.

Background:
	Given I am on the Radio and Checkboxes page

Scenario: Selecting a radio button
	When I select the radio button for "Yes"
	And I select the radio button for "No"
	Then I should see "No" is selected
	And I should see "Yes" is not selected

Scenario: Confirming a radio button option is disabled
	Then the radio button for "Maybe" is disabled

Scenario: Selecting a checkbox
	When I select the checkbox for accepting the T&C
	Then I should see the T&C checkbox is selected