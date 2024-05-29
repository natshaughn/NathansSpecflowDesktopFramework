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
            string fileName = FileMenu.ReturnFileName();
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, $"{fileName}.docx");

            SpinWait.SpinUntil(() => File.Exists(filePath), TimeSpan.FromSeconds(30));
            Assert.That(File.Exists(filePath), Is.True, $"File '{filePath}' was not found."); 
        }


        [Then(@"a PDF file will be created in the desktop directory")]
        public void ThenAPDFFileWillBeCreatedInTheDesktopDirectory()
        {
            string fileName = FileMenu.ReturnFileName();
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, $"{fileName}.pdf");

            SpinWait.SpinUntil(() => File.Exists(filePath), TimeSpan.FromSeconds(30));
            Assert.That(File.Exists(filePath), Is.True, $"PDF '{filePath}' was not found.");
        }
    }
}
