using NathansSpecflowDesktopFramework.Application.Elements;
using System.Collections.ObjectModel;

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
        public ElementWrapper FontOption => new(driver, By.Name("Font"));
        public ElementWrapper OpenFontButton => new(driver, By.Name("Open"));
        public ElementWrapper PageContent => new(driver, By.Name("Page 1 content"));

        public void ClickOpenFontButton()
        {
            OpenFontButton.Click();
        }

        public void ClickPageContent()
        {
            PageContent.Click();
        }

        public void CreateNewDocAndPasteInChars(int numberOfChars)
        {
            homeMenu.ClickNewBlankDocButton();
            string textToPaste = new string('a', numberOfChars);
            ClickPageContent();
            IWebElement activeElement = driver.SwitchTo().ActiveElement();
            activeElement.SendKeys(textToPaste);
        }

        public string FontTextBoxValue(string text)
        {
            FontOption.WaitForElement();
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Name(text));
            string elementText = "";
            foreach (IWebElement element in elements)
            {
                if (element.GetAttribute("Value.Value") == "Aptos (Body)")
                {
                    elementText = element.GetAttribute("Value.Value");
                    return elementText;
                }
            }
            return elementText;
        }
    }
}
