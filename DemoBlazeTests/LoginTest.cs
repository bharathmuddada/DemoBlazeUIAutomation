using DemoBlazeCoreFW;
using DemoBlazePages.Pages;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoBlazeTests
{
    public class LoginTest :BaseTest
    {
       
        [Test]
        public void LoginTest1()
        {
            var headerBar = new HeaderBar(Driver.current);
            
            LoginPage loginpage = headerBar.ClickLoginLink();

            loginpage.DoLogin(String.Empty,String.Empty);

            Assert.IsTrue(loginpage.NoUsernameAndPassword());
        }

        [Test]
        public void LoginTest2()
        {
            var headerBar = new HeaderBar(Driver.current);

            LoginPage loginpage = headerBar.ClickLoginLink();

            loginpage.DoLogin("rand", "password1");

            Assert.IsTrue(loginpage.WrongPassword());
        }

        [Test]
        public void LoginTest3()
        {
            var headerBar = new HeaderBar(Driver.current);

            LoginPage loginpage = headerBar.ClickLoginLink();

            loginpage.DoLogin("AutomationUser", "happy");

            Assert.That(loginpage.getLoggedinUserName(), Is.EqualTo("Welcome AutomationUser"));
        }
    }
}