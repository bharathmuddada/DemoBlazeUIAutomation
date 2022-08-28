using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoBlazeCoreFW
{
    public static class Driver
    {
        [ThreadStatic]
        public static IWebDriver? driver;


        public static IWebDriver current
        {
            get
            {
                return driver;
            }
        }

        public static void init(string browsername) {

            if(string.Equals(browsername, "chrome", StringComparison.OrdinalIgnoreCase))
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
              
            }
            else if (string.Equals(browsername, "firefox", StringComparison.OrdinalIgnoreCase))
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();
              
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        public static void getScreenshot(string screenshot_path)
        {

            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile(screenshot_path, ScreenshotImageFormat.Png);


        }
    }
}
