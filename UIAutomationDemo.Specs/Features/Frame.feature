@playwright
Feature: Frame
	Interacting with Frames in a web application.

Scenario: Entering details in a Frame
	Given I am on the Frame page
	When I enter the first name "Mickey"
	And I enter the last name "Mouse"
	And I enter the email "mickeymouse@gmail.com"
	Then I should see these are all entered into the fields