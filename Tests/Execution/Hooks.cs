using BoDi;
using NathansSpecflowDesktopFramework.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace NathansSpecflowDesktopFramework.Tests.Execution
{
    [Binding]
    public class Hooks
    {
        public IObjectContainer ObjectContainer { get; set; }

        public Hooks(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // Initialise driver before each scenario
            WindowsDriver<WindowsElement> desktopSession = DriverManager.Setup();
            SpinWait.SpinUntil(() => desktopSession.FindElements(By.Name("New blank document")).Any(), TimeSpan.FromSeconds(30)); // Add to API Framework

            ObjectContainer.RegisterInstanceAs(desktopSession);
        }

        [AfterScenario]
        public void AfterScenario(ObjectContainer objectContainer)
        {
            WindowsDriver<WindowsElement> driver = objectContainer.Resolve<WindowsDriver<WindowsElement>>();
            DriverManager.QuitSession(driver);
        }
    }
}
