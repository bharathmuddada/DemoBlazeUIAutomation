﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

        public static void init() {

            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


        }

        public static void getScreenshot(String filename)
        {

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            //var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now.Ticks + ".png";
            var path = "C:\\Users\\Bharath\\source\\repos\\DemoBlazeUIAutomation\\Allure-Results\\" + filename;
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);


        }
    }
}
