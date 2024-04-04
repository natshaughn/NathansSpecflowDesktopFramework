using NathansSpecflowDesktopFramework.Drivers;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;

namespace NathansSpecflowDesktopFramework.Tests.StepDefinitions
{
    [Binding]
    public class FileExplorerSteps
    {
        // Obtain the driver instance from the DriverManager
        WindowsDriver<WindowsElement> sessionWord = DriverManager.GetDriver();

        [Then(@"the document will be created and saved in the desktop directory")]
        public void ThenTheDocumentWillBeCreatedAndSavedInTheDesktopDirectory()
        {
            // NEEDS WORK HERE IT'S NOT CLICKING FILE EXPLORER 
            sessionWord.FindElementByName("File Explorer").Click();
            sessionWord.FindElementByName("Downloads (pinned)").Click();
            // Get the random file name generated in the previous step
            string randomFileName = FileMenuSteps.GetRandomFileName();

            sessionWord.FindElementByName(randomFileName);
            // Verify that the file exists
            Assert.IsTrue(File.Exists(randomFileName), "File was not saved");
        }

        [Then(@"a PDF file will be created in the desktop directory")]
        public void ThenAPDFFileWillBeCreatedInTheDesktopDirectory()
        {
            throw new PendingStepException();
        }       
    }
}
