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
        public void Click()
        {
            FindElement().Click();
        }

        public bool Exists()
        {
            return driver.FindElements(by).Count() > 0;
        }

        public IWebElement FindElement()
        {
            return driver.FindElement(by);
        }

        public string GetElementText()
        {
            return FindElement().Text;
        }
        public void SendKeys(string text)
        {
            FindElement().SendKeys(text);
        }

        public void WaitForElement()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        public void WaitUntilExists()
        {
            SpinWait.SpinUntil(() => Exists(), TimeSpan.FromSeconds(30));
        }
    }
}
