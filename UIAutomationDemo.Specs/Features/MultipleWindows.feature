@playwright
Feature: Multiple Windows
	Interacting with Multiple Windows or Tabs that open in a web application.

Background:
	Given I am on the Windows page

Scenario: Opening another tab
	When I open another tab for the Homepage
	Then I should see that 2 tabs are open
	And I should see the new tab is for the Homepage

Scenario: Closing an opened tab
	When I open another tab for the Homepage
	And I close the Homepage tab
	Then I should see the Homepage tab has been closed

Scenario: Opening multiple windows
	When I open multiple windows
	Then I should see that 3 windows are open
	And I should see that one window is for Alerts
	And I should see that one window is for Dropdowns

Scenario: Closing multiple opened windows
	When I open multiple windows
	And I close all windows but the first
	Then I should see only the Windows page is open