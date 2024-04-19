using BoDi;
using NathansSpecflowDesktopFramework.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using NathansWebAutomationFramework.Utility;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace NathansSpecflowDesktopFramework.Tests.Execution
{
    [Binding]
    public class Hooks : ExtentReport // :... = Inherit extent report class
    {
        public IObjectContainer ObjectContainer { get; set; }

        public Hooks(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInit(); // Calling this method - defined where generate extent report and configs in here too 
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportTearDown(); // calling this method in ExtentReport class - flushing/ creating extent report
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext) // feature context reference variable - can get feature name 
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
                       // extent reports object - calling CreateTest method <Feature> = Gherkin keyword - get feature name, getting the title will get title of any feature file
                       // Create test, assign to _feature
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            // Initialise driver before each scenario
            WindowsDriver<WindowsElement> desktopSession = DriverManager.Setup();
            SpinWait.SpinUntil(() => desktopSession.FindElements(By.Name("New blank document")).Any(), TimeSpan.FromSeconds(30)); // Add to API Framework

            ObjectContainer.RegisterInstanceAs(desktopSession);

            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            // After creating _feature, then do same with scenario, get scenario name
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext, ObjectContainer objectContainer)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString(); // returns type of gherkin keyword e.g. given, when then
            string stepName = scenarioContext.StepContext.StepInfo.Text; // returns step name e.g. .I click on ... 

            WindowsDriver<WindowsElement> driver = objectContainer.Resolve<WindowsDriver<WindowsElement>>();

            if (scenarioContext.TestError == null) // if passed
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName); // create node
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
            }

            // When scenario fails 
            if (scenarioContext.TestError != null)
            {               
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build()); // create node
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

        [AfterScenario]
        public void AfterScenario(ObjectContainer objectContainer)
        {
            WindowsDriver<WindowsElement> driver = objectContainer.Resolve<WindowsDriver<WindowsElement>>();
            DriverManager.QuitSession(driver);
        }
    }
}
