Feature: CreateWordDoc

Create a new Word document 

Scenario: Create a new Word document
	Given I click on a Blank Document from the Home menu
	When a new blank document is opened
	Then the default font is 'Calibri (Boduy)'
