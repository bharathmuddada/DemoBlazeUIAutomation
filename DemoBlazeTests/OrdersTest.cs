using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazeTests
{
    public class OrdersTest : BaseTest
    {
        [Test]
        public void AddPhoneToCart() {

            string productname = "Samsung galaxy s6";
            string menusection = "Phones";
            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.ClickLoginLink();

            HomePage homepage = loginpage.DoLogin("AutomationUser", "happy");

            homepage.clickOnMenu(menusection);
            ProductPage productPage = homepage.SelectItemToView(productname);
            CartPage cartpage = productPage.AddProductToCart();
            
            Assert.That(cartpage.GetProductName(),Is.EqualTo(productname)); 


        }

        [Test]
        public void AddLaptopToCart()
        {

            string productname = "Sony vaio i5";
            string menusection = "Laptops";
            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.ClickLoginLink();

            HomePage homepage = loginpage.DoLogin("AutomationUser", "happy");

            homepage.clickOnMenu(menusection);
            ProductPage productPage = homepage.SelectItemToView(productname);
            CartPage cartpage = productPage.AddProductToCart();

            Assert.That(cartpage.GetProductName(), Is.EqualTo(productname));


        }
    }
}
