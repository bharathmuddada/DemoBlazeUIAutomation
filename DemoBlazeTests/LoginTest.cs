using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoBlazeTests
{
    [Parallelizable(ParallelScope.All)]
    public class LoginTest :BaseTest
    {
       
        [Test]
        public void LoginWithEmptyCredentials()
        {
            HeaderNav headernav = new HeaderNav(Driver.current);

          
            LoginPage loginpage = headernav.ClickLoginLink();
           
            loginpage.DoLogin(string.Empty,string.Empty);

            Assert.That(loginpage.NoUsernameAndPassword(), Is.True);
        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.ClickLoginLink();

            loginpage.DoLogin("AutomationUser", "InvalidPassword:");

            Assert.That(loginpage.WrongPassword(), Is.True);
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.ClickLoginLink();

            loginpage.DoLogin("AutomationUser", "happy");

            Assert.That(loginpage.GetLoggedinUserName(), Is.EqualTo("Welcome AutomationUser"));
        }
    }
}