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
        private string expectedText = new string('a', 100);

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
            PDFText = PDFText.Replace("\n", ""); 
            Assert.That(PDFText, Is.EqualTo(expectedText), $"Expected PDF Text: {expectedText}, Actual font: {PDFText}");
        }
    }
}
