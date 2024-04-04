Feature: SaveWordDoc

Save a Word document

Scenario: Create and save a document using Save as from the File menu
	Given I create a new document and paste in 100 characters
	When When I save the file onto the desktop with a random name
	Then the document will be created and saved in the desktop directory
