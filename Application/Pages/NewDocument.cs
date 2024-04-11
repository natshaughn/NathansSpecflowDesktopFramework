using NathansSpecflowDesktopFramework.Application.Elements;
using OpenQA.Selenium;

namespace NathansSpecflowDesktopFramework.Application.Pages
{
    public class NewDocument
    {
        private readonly IWebDriver driver;
        private readonly HomeMenu homeMenu;

        public NewDocument(IWebDriver driver)
        {
            this.driver = driver;
            homeMenu = new HomeMenu(driver); 
        }

        public ElementWrapper FontOption => new ElementWrapper(driver, By.Name("Font"));
        public ElementWrapper PageContent => new ElementWrapper(driver, By.Name("Page 1 content"));
    
        public void ClickPageContent()
        {
            PageContent.Click();
        }

        public void CreateNewDocAndPasteInChars(int numberOfChars)
        {
            homeMenu.ClickNewBlankDocButton();
            // Generate text to paste
            string textToPaste = new string('a', numberOfChars);
            ClickPageContent();

            // Get the active element (usually the focused element)
            IWebElement activeElement = driver.SwitchTo().ActiveElement();

            // Send keys to the active element
            activeElement.SendKeys(textToPaste);
        }      
    }
}
