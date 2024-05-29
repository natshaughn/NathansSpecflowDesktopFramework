using NathansSpecflowDesktopFramework.Application.Elements;

namespace NathansSpecflowDesktopFramework.Application.Pages
{
    public class HomeMenu
    {
        private readonly IWebDriver driver;

        public HomeMenu(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ElementWrapper NewBlankDocButton => new(driver, By.Name("New blank document"));

        public void ClickNewBlankDocButton()
        {
            NewBlankDocButton.WaitForElement();
            NewBlankDocButton.Click();
        }
    }
}
