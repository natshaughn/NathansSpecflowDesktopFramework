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

        

/*        [Then(@"the document will be created and saved in the desktop directory")]
        public void ThenTheDocumentWillBeCreatedAndSavedInTheDesktopDirectory()
        {
            // Open File Explorer
            DriverManager.OpenFileExplorer();

            // Find and click on the Downloads element
            var downloadsElement = DriverManager.GetDriver().FindElementByName("Downloads (pinned)");
            downloadsElement.Click();

            // Get the random file name generated in the previous step
            string randomFileName = FileMenuSteps.GetRandomFileName();

            // Verify that the file exists in the Downloads directory
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", randomFileName);
            Assert.IsTrue(File.Exists(filePath), $"File '{randomFileName}' was not saved in the Downloads directory");
        }*/


        [Then(@"a PDF file will be created in the desktop directory")]
        public void ThenAPDFFileWillBeCreatedInTheDesktopDirectory()
        {
            throw new PendingStepException();
        }       
    }
}
