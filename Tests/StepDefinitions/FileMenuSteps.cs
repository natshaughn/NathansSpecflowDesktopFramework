using NathansSpecflowDesktopFramework.Application.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;

namespace NathansSpecflowDesktopFramework.Tests.StepDefinitions
{
    [Binding]
    public class FileMenuSteps
    {   
        private readonly FileMenu fileMenu;

        public FileMenuSteps(WindowsDriver<WindowsElement> driver)
        {
            fileMenu = new FileMenu(driver);
        }

        [When(@"When I save the file onto the desktop with a random name")]
        public void WhenWhenISaveTheFileOntoTheDesktopWithARandomName()
        {
            fileMenu.SaveAFileWithRandomName();
        }     

        [When(@"I save document as a pdf document to the desktop")]
        public void WhenISaveDocumentAsAPdfDocumentToTheDesktop()
        {
            fileMenu.SavePDFDocumentToDesktop();
        }

        [Then(@"the document will be created and saved in the desktop directory")]
        public void ThenTheDocumentWillBeCreatedAndSavedInTheDesktopDirectory()
        {
            // Get the random file name 
            string fileName = FileMenu.ReturnFileName();
            Console.WriteLine(fileName);

            // Assert that the document with the random file name exists on the desktop
            Assert.That(File.Exists($"C:\\Users\\nathan.shaughnessy\\Downloads\\{fileName}.docx"), Is.True, $"File '{fileName}' was not found in the desktop directory.");
        }


        [Then(@"a PDF file will be created in the desktop directory")]
        public void ThenAPDFFileWillBeCreatedInTheDesktopDirectory()
        {
            // Get the random file name 
            string fileName = FileMenu.ReturnFileName();
            Console.WriteLine(fileName);

            // Assert that the PDF with the random file name exists on the desktop
            Assert.That(File.Exists($"C:\\Users\\nathan.shaughnessy\\Downloads\\{fileName}.pdf"), Is.True, $"PDF '{fileName}' was not found in the desktop directory.");
        }
    }
}
