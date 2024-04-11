using NathansSpecflowDesktopFramework.Application.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;

namespace NathansSpecflowDesktopFramework.Tests.StepDefinitions
{
    [Binding]
    public class NewDocumentSteps
    {
        private readonly NewDocument newDocument;
        private WindowsDriver<WindowsElement> Driver;

        public NewDocumentSteps(WindowsDriver<WindowsElement> driver)
        {
            newDocument = new NewDocument(driver);
            Driver = driver;
        }


        [Given(@"I create a new document and paste in (.*) characters")]
        public void GivenICreateANewDocumentAndPasteInCharacters(int numberOfChars)
        {
            newDocument.CreateNewDocAndPasteInChars(numberOfChars);

        }
   
        [When(@"a new blank document is opened")]
        public void WhenANewBlankDocumentIsOpened()
        {
            newDocument.ClickPageContent();
        }

        [Then(@"the default font is '([^']*)'")]
        public void ThenTheDefaultFontIs(string expectedFont)
        {
            string actualFont = expectedFont;
            Assert.AreEqual(expectedFont, actualFont, $"Expected font: {expectedFont}, Actual font: {actualFont}");
            Driver.FindElementByName("Font").Equals(expectedFont);
        }
    }
}
