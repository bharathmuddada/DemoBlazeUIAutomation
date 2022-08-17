using DemoBlazeCoreFW;
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
    public class BaseTest 
    {

     
        [SetUp]
        public void Setup()
        {
            Driver.init();
            Driver.current.Navigate().GoToUrl("https://www.demoblaze.com/");

        }

        [TearDown]
        public void TearDown()
        {
            Driver.current.Quit();
        }
    }
}
