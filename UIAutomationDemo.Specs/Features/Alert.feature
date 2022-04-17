@playwright
Feature: Alert
	Interacting with Alerts in a web application.

Background:
	Given I am on the Alert page

Scenario: Accepting an Alert
	Given I want to accept an open alert
	When I open the simple alert and accept it
	Then the alert should be closed

Scenario: Dismissing an Alert
	Given I want to dismiss an open alert
	When I open the confirm alert and dismiss it
	Then the alert should be closed

Scenario: Getting an Alert text
	Given I want to get an open alert's message
	And I want to dismiss it
	When I open the confirm alert and dismiss it
	Then I should have the alert text

Scenario: Confirming a Prompt Alert
	Given I want to confirm an open prompt alert with "Spongebob"
	When I open and confirm the prompt alert
	Then the alert should be closed

Scenario: Closing a Modern Alert
	When I open the modern alert and close it
	Then the alert should be closed