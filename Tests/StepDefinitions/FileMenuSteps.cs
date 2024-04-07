using NathansSpecflowDesktopFramework.Drivers;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;

namespace NathansSpecflowDesktopFramework.Tests.StepDefinitions
{
    [Binding]
    public class FileMenuSteps
    {
        private static string randomFileName;

        // Obtain the driver instance from the DriverManager
        WindowsDriver<WindowsElement> sessionWord = DriverManager.GetDriver();

        [When(@"When I save the file onto the desktop with a random name")]
        public void WhenWhenISaveTheFileOntoTheDesktopWithARandomName()
        {
            sessionWord.FindElementByName("File Tab").Click();
            sessionWord.FindElementByName("Save As").Click();
            // Generate a random file name
            randomFileName = Path.Combine(Path.GetRandomFileName());
            sessionWord.FindElementByName("Enter file name here").SendKeys(randomFileName);
            sessionWord.FindElementByName("OneDrive - ROQ IT").Click();
            Thread.Sleep(5000);
            sessionWord.FindElementByName("Downloads (pinned)").Click();
            sessionWord.FindElementByName("Save").Click();
            // Wait for the file to be saved (adjust sleep duration as needed)
            Thread.Sleep(5000);
        }

        public static string GetRandomFileName()
        {
            return randomFileName;
        }

        [When(@"I save document as a pdf document to the desktop")]
        public void WhenISaveDocumentAsAPdfDocumentToTheDesktop()
        {
            throw new PendingStepException();
        }

        [Then(@"the document will be created and saved in the desktop directory")]
        public void ThenTheDocumentWillBeCreatedAndSavedInTheDesktopDirectory()
        {
            sessionWord.FindElementByName("File Tab").Click();
            Thread.Sleep(3000);
            sessionWord.FindElementByName("Open").Click();
            Thread.Sleep(3000);
            // Get the random file name generated in the previous step
            string randomFileName = GetRandomFileName();
            var file = sessionWord.FindElementByName($"{randomFileName}.docx");
            Assert.IsNotNull(file, $"File '{randomFileName}' was not found in the desktop directory.");
        }
    }
}
