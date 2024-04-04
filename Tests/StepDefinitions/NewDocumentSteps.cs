using NathansSpecflowDesktopFramework.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace NathansSpecflowDesktopFramework.Tests.StepDefinitions
{
    [Binding]
    public class NewDocumentSteps
    {
        // Obtain the driver instance from the DriverManager
        WindowsDriver<WindowsElement> sessionWord = DriverManager.GetDriver();

        [Given(@"I create a new document and paste in (.*) characters")]
        public void GivenICreateANewDocumentAndPasteInCharacters(int p0)
        {
            // Perform actions on the application using the driver
            sessionWord.FindElementByName("New blank document").Click();

            Thread.Sleep(5000);

            var pageContent = sessionWord.FindElementByName("Page 1 content");

            string textToPaste = new string('a', p0);

            // Click to focus on the element
            pageContent.Click();

            // Perform paste operation by sending keys
            sessionWord.Keyboard.SendKeys(textToPaste);

        }
   
        [When(@"a new blank document is opened")]
        public void WhenANewBlankDocumentIsOpened()
        {
            sessionWord.FindElementByName("Page 1 content").Click();
        }

        [Then(@"the default font is '([^']*)'")]
        public void ThenTheDefaultFontIs(string p0)
        {
            sessionWord.FindElementByName("Font").Equals(p0);
        }
    }
}
