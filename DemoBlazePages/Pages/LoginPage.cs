using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazePages.Pages
{
    public class LoginPage : BasePage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement user_name => driver.FindElement(By.Id("loginusername"));

        public IWebElement password_field => driver.FindElement(By.Id("loginpassword"));

        public IWebElement loginbutton => driver.FindElement(By.XPath("//div[@class='modal-footer']//button[text()='Log in']"));

        public IWebElement loggedin_user_name => driver.FindElement(By.XPath("//a[@id='nameofuser']"));
        public HomePage DoLogin(string username, string password) {

            user_name.SendKeys(username);
            password_field.SendKeys(password);
            loginbutton.Click();
            return new HomePage(driver);

        }


        public Boolean NoUsernameAndPassword() {

            IAlert alert = driver.SwitchTo().Alert();
            String message =alert.Text;
            Console.WriteLine(message);
            return message == "Please fill out Username and Password.";

        }

        public Boolean WrongPassword()
        {

            IAlert alert = driver.SwitchTo().Alert();
            string message = alert.Text;
            Console.WriteLine(message);
            return message == "Wrong password.";

        }

        public string getLoggedinUserName() {

            return loggedin_user_name.Text;
        }





    }
}
