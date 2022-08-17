using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazePages.Pages
{
    public class HeaderBar
    {
        IWebDriver driver;

        public HeaderBar(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement home_link => driver.FindElement(By.XPath("//a[contains(text(),'Home')]"));

        public IWebElement contact_link => driver.FindElement(By.XPath("//a[contains(text(),'Contact')]"));

        public IWebElement aboutus_link => driver.FindElement(By.XPath("//a[contains(text(),'About')]"));

        public IWebElement Cart_link => driver.FindElement(By.XPath("//a[contains(text(),'Cart')]"));

        public IWebElement Login_link => driver.FindElement(By.XPath("//a[contains(text(),'Log in')]"));


        public LoginPage ClickLoginLink() {
            Login_link.Click();
            return new LoginPage(driver);

        }


    }
}
