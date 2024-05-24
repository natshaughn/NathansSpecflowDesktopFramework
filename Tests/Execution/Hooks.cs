using BoDi;
using NathansSpecflowDesktopFramework.Drivers;
using OpenQA.Selenium.Appium.Windows;
using NathansWebAutomationFramework.Utility;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace NathansSpecflowDesktopFramework.Tests.Execution
{
    [Binding]
    public class Hooks : ExtentReport
    {
        public IObjectContainer ObjectContainer { get; set; }

        public Hooks(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportTearDown(); 
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext) 
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            WindowsDriver<WindowsElement> desktopSession = DriverManager.Setup();
            SpinWait.SpinUntil(() => desktopSession.FindElements(By.Name("New blank document")).Any(), TimeSpan.FromSeconds(30));
            ObjectContainer.RegisterInstanceAs(desktopSession);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario(ObjectContainer objectContainer)
        {
            WindowsDriver<WindowsElement> driver = objectContainer.Resolve<WindowsDriver<WindowsElement>>();
            DriverManager.QuitSession(driver);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext, ObjectContainer objectContainer)
        {
            WindowsDriver<WindowsElement> driver = objectContainer.Resolve<WindowsDriver<WindowsElement>>();

            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString(); 
            string stepName = scenarioContext.StepContext.StepInfo.Text; 

            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName); 
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            } else {               
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build()); 
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
    }
}
