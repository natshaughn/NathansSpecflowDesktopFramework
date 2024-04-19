using NathansSpecflowDesktopFramework.Application.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;

namespace NathansSpecflowDesktopFramework.Tests.StepDefinitions
{
    [Binding]
    public class NewPDFSteps
    {
        private readonly NewPDF newPDF;
        private WindowsDriver<WindowsElement> Driver;
        private string expectedText = new string('a', 100); // Generates a string of 100 'a' characters

        public NewPDFSteps(WindowsDriver<WindowsElement> driver)
        {
            newPDF = new NewPDF(driver);
            Driver = driver;
        }

        [Then(@"the PDF file will contain the correct text")]
        public void ThenThePDFFileWillContainTheCorrectText()
        {
            string PDFText = newPDF.ExtractTextFromPDF();
            PDFText = PDFText.Trim();
            PDFText = PDFText.Replace("\n", ""); // Remove newline characters

            Console.WriteLine(PDFText);
            // Compare the extracted text with the expected text
            Assert.That(PDFText, Is.EqualTo(expectedText));
        }
    }
}
