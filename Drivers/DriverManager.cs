using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NathansSpecflowDesktopFramework.Drivers
{
    public class DriverManager
    {
        private static WindowsDriver<WindowsElement>? driver;

        public static WindowsDriver<WindowsElement> GetDriver()
        {
            if (driver == null)
            {
                // Initialize AppiumOptions and set desired capabilities
                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability("app", @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE");

                // Initialize Appium Windows Driver
                driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            }
            return driver;
        }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null; // Reset the driver instance after quitting
            }
        }
    }
}

