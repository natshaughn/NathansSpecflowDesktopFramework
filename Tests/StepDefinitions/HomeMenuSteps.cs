using NathansSpecflowDesktopFramework.Application.Pages;
using OpenQA.Selenium.Appium.Windows;

namespace NathansSpecflowDesktopFramework.Tests.StepDefinitions
{
    [Binding]
    public class HomeMenuSteps
    {
        private readonly HomeMenu homeMenu;

        public HomeMenuSteps(WindowsDriver<WindowsElement> driver)
        {
            homeMenu = new HomeMenu(driver);
        }

        [Given(@"I click on a Blank Document from the Home menu")]
        public void GivenIClickOnABlankDocumentFromTheHomeMenu()
        {
            homeMenu.ClickNewBlankDocButton();   
        }
    }
}
