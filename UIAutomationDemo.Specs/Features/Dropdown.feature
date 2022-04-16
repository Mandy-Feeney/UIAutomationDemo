@playwright
Feature: Dropdown
	Interacting with Dropdowns in a web application.

Background:
	Given I am on the Dropdown page

Scenario: Selecting an option by visible text from a Dropdown
	When I select "Apple" by its visible text from the fruit dropdown
	Then I should see "Apple" is the selected fruit

Scenario: Selecting multiple options from a Dropdown
	Given my favourite superheroes are:
	| Superhero  | Abbreviation |
	| Batman     | bt           |
	| Iron Man	 | im           |
	| Wolverine  | wv           |
	When I select each of these options from the superhero dropdown
	Then I should see all of my favourite superheroes are selected

Scenario: Selecting the last option in a Dropdown
	When I select the last programming language from the dropdown
	Then I should see "C#" is the selected programming language

Scenario: Getting all the options from a Dropdown
	When I get all the programming languages from the dropdown
	Then I should see all programming languages from the dropdown

Scenario: Selecting an option by value from a Dropdown
	When I select "India" by its value from the country dropdown
	Then I should see "India" is the selected country