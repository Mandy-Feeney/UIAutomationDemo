@playwright
Feature: Elements
	Interacting with Elements in a web application.

Scenario: Searching Git user profiles
	Given I am on the Elements page
	When I search for the Git user "Mandy-Feeney"
	Then I should see the Git user "Mandy Feeney" can be found
	And I should see a profile image is displayed
	And I should see the number of public repos