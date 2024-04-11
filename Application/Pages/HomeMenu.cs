using NathansSpecflowDesktopFramework.Application.Elements;
using OpenQA.Selenium;

namespace NathansSpecflowDesktopFramework.Application.Pages
{
    public class HomeMenu
    {
        private readonly IWebDriver driver;

        public HomeMenu(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ElementWrapper NewBlankDocButton => new ElementWrapper(driver, By.Name("New blank document"));

        public void ClickNewBlankDocButton()
        {
            NewBlankDocButton.Click();
        }
    }
}
