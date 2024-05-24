using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace NathansWebAutomationFramework.Utility
{
    public class ExtentReport
    {
        public static ExtentReports? _extentReports;
        public static ExtentTest? _feature;
        public static ExtentTest? _scenario;

        public static string dir = AppDomain.CurrentDomain.BaseDirectory; 
        public static string testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults"); 

        public static void ExtentReportInit() 
        {           
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(testResultPath);  
            htmlReporter.Config.ReportName = "Desktop Automation Status Report"; 
            htmlReporter.Config.DocumentTitle = "Desktop Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start(); 

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Word");
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush(); 
        }

        public string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
            return screenshotLocation;
        }
    }
}
