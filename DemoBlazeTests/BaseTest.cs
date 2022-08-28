using Allure.Commons;
using DemoBlazeCoreFW;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoBlazeTests
{
    [AllureNUnit]
    public class BaseTest 
    {
        [OneTimeSetUp]
        public void CleanupResultDirectory()
        {
            AllureExtensions.WrapSetUpTearDownParams(() => { AllureLifecycle.Instance.CleanupResultDirectory(); },
                "Clear Allure Results Directory");
        }

        [SetUp]
        public void Setup()
        {
            var browsername = ConfigReaderHelpers.GetconfigDetails("browsername");
            var url = ConfigReaderHelpers.GetconfigDetails("applicationurl");
            Driver.init(browsername);
            Driver.current.Navigate().GoToUrl(url);


        }

        //[TearDown]
        //public void TearDown()
        //{
        //    Driver.current.Quit();
        //}

        [TearDown]
        public void CloseBrowser()
        {

            //if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            //{
            var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now.Ticks + ".png";
            //Driver.getScreenshot(filename);
            var ss_path = Directory.GetCurrentDirectory()+$"\\allure-results\\{filename}";
            Driver.getScreenshot(ss_path);
            //var path = "C:\\Users\\Bharath\\source\\repos\\DemoBlazeUIAutomation\\Allure-Results\\" + filename;
            //TestContext.AddTestAttachment(ss_path);
            AllureLifecycle.Instance.AddAttachment(filename,"image/png", ss_path);

            Driver.current.Quit();

        }
    }
}
