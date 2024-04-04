using NathansSpecflowDesktopFramework.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NathansSpecflowDesktopFramework.Tests.Execution
{
    public class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            // Initialize driver before each scenario
            DriverManager.GetDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Clean up resources after each scenario (if needed)
            DriverManager.QuitDriver();
        }
    }
}
