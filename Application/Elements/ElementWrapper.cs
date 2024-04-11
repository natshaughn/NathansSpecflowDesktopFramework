using OpenQA.Selenium;

namespace NathansSpecflowDesktopFramework.Application.Elements
{
    public class ElementWrapper
    {
        private readonly IWebDriver driver;
        private readonly By by;

        public ElementWrapper(IWebDriver driver, By by)
        {
            this.driver = driver;
            this.by = by;
        }

        // Find a single element 
        public IWebElement FindElement()
        {
            return driver.FindElement(by);
        }

        // Click an element 
        public void Click()
        {
            FindElement().Click();
        }

        // Type text 
        public void SendKeys(string text)
        {
            FindElement().SendKeys(text); 
        }

        // Get the text of the element
        public string GetElementText()
        {
            return FindElement().Text;
        }
    }
}
