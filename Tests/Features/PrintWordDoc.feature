Feature: PrintWordDoc

Print a Word document to PDF

Scenario: Print Word document to PDF
	Given I create a new document and paste in 100 characters
	When I save document as a pdf document to the desktop
	Then a PDF file will be created in the desktop directory
	And the PDF file will contain the correct text
