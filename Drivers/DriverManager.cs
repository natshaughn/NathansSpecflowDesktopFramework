using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;

namespace NathansSpecflowDesktopFramework.Drivers
{
    public class DriverManager
    {
        public const string DriverUrl = "http://127.0.0.1:4723";

        public static WindowsDriver<WindowsElement> Setup()
        {
            Process.GetProcessesByName("WinAppDriver").ToList().ForEach(x =>
            {
                x.Kill();
                x.WaitForExit();
            });


            Process.GetProcessesByName("WINWORD").ToList().ForEach(x =>
            {
                x.Kill();
                x.WaitForExit();
            });

            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");

            // Initialise AppiumOptions and set desired capabilities
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("ms:waitForAppLaunch", "10");

            // Initialise Appium Windows Driver
            WindowsDriver<WindowsElement> desktopSession = new WindowsDriver<WindowsElement>(new Uri(DriverUrl), options);

            return desktopSession;
        }

        public static void QuitSession(WindowsDriver<WindowsElement> desktopSession)
        {
            if (desktopSession != null)
            {
                desktopSession.Close();
                desktopSession.Quit();
                
            } 

            Process.GetProcessesByName("WINWORD").ToList().ForEach(x => x.Kill());
            Process.GetProcessesByName("WinAppDriver").ToList().ForEach(x => x.Kill());
            Process.GetProcessesByName("Acrobat").ToList().ForEach(x => x.Kill());
        }
    }
}
