using NathansSpecflowDesktopFramework.Drivers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace NathansSpecflowDesktopFramework.Tests.StepDefinitions
{
    [Binding]
    public class HomeMenuSteps
    {
        // Obtain the driver instance from the DriverManager
        WindowsDriver<WindowsElement> sessionWord = DriverManager.GetDriver();

        [Given(@"I click on a Blank Document from the Home menu")]
        public void GivenIClickOnABlankDocumentFromTheHomeMenu()
        {
            Thread.Sleep(5000);
            // Perform actions on the application using the driver
            sessionWord.FindElementByName("New blank document").Click();          
        }
    }
}
