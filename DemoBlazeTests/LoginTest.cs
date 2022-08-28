
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoBlazeTests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [AllureSuite("DemoBlazeUI - LoginTests")]
    public class LoginTest :BaseTest
    {
       
        [Test]
        [AllureName(name: "Login with empty credentials")]
        public void LoginWithEmptyCredentials()
        {
            HeaderNav headernav = new HeaderNav(Driver.current);

          
            LoginPage loginpage = headernav.NavigateToLoginPage();
           
            loginpage.DoLogin(string.Empty,string.Empty);

            AllureLifecycle.Instance.WrapInStep( () => {
                Assert.That(loginpage.NoUsernameAndPassword(), Is.True); },"Validate empty credentials");
        }

        [Test]
        [AllureName(name: "Login with invalid credentials")]
        public void LoginWithInValidCredentials()
        {
            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.NavigateToLoginPage();

            loginpage.DoLogin("AutomationUser", "InvalidPassword:");

            Assert.That(loginpage.WrongPassword(), Is.True);
        }

        [Test]
        [AllureName(name: "Login with valid credentials")]
        public void LoginWithValidCredentials()
        {
            string username = ConfigReaderHelpers.GetconfigDetails("username");
            string password = ConfigReaderHelpers.GetconfigDetails("password");

            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.NavigateToLoginPage();

            loginpage.DoLogin(username, password);

            Assert.That(loginpage.GetLoggedinUserName(), Is.EqualTo("Welcome AutomationUser"));
        }

       
    }
}