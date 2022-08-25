
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazeTests
{
    [Parallelizable]
    [AllureNUnit]
    [AllureSuite("DemoBlazeUI - Orders Tests")]
    public class OrdersTest : BaseTest
    {
        [Test]
        [AllureName(name: "Add Phone to cart")]
        public void AddPhoneToCart() {

            string productname = "Samsung galaxy s6";
            string menusection = "Phones";
            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.NavigateToLoginPage();

            HomePage homepage = loginpage.DoLogin("AutomationUser", "happy");

            homepage.clickOnMenu(menusection);
            ProductPage productPage = homepage.SelectItemToView(productname);
            CartPage cartpage = productPage.AddProductToCart();
            
            Assert.That(cartpage.GetProductNames(),Has.Member(productname));

            //cleanup
            cartpage.DeleteItemFromCart();


        }

        [Test]
        [AllureName(name: "Add Laptop to cart")]
        public void AddLaptopToCart()
        {

            string productname = "Sony vaio i5";
            string menusection = "Laptops";
            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.NavigateToLoginPage();

            HomePage homepage = loginpage.DoLogin("AutomationUser", "happy");

            homepage.clickOnMenu(menusection);
            ProductPage productPage = homepage.SelectItemToView(productname);
            CartPage cartpage = productPage.AddProductToCart();

            Assert.That(cartpage.GetProductNames(), Has.Member(productname));

            //cleanup
            cartpage.DeleteItemFromCart();


        }


        [TestCaseSource(typeof(TestData), nameof(TestData.OrdersTestData))]
        public void AddProductToCart( string menusection,string productname)
        {

            //string productname = "Sony vaio i5";
            //string menusection = "Laptops";
            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.NavigateToLoginPage();

            HomePage homepage = loginpage.DoLogin("AutomationUser", "happy");

            homepage.clickOnMenu(menusection);
            ProductPage productPage = homepage.SelectItemToView(productname);
            CartPage cartpage = productPage.AddProductToCart();

            Assert.That(cartpage.GetProductNames(), Has.Member(productname));

            //cleanup
            cartpage.DeleteItemFromCart();

        }

        [Test]
        public void PlaceOrderForPhone()
        {

            string productname = "Samsung galaxy s6";
            string menusection = "Phones";


            HeaderNav headernavigation = new HeaderNav(Driver.current);

            LoginPage loginpage = headernavigation.NavigateToLoginPage();

            HomePage homepage = loginpage.DoLogin("AutomationUser", "happy");

            homepage.clickOnMenu(menusection);
            ProductPage productPage = homepage.SelectItemToView(productname);
            CartPage cartpage = productPage.AddProductToCart();
            Assert.That(cartpage.GetProductNames(), Has.Member(productname));
            //string thankyouheader = cartpage.PlaceOrder();

            //Assert.That(thankyouheader,Is.EqualTo("Thank you for your purchase!"));


            //Assert.That(cartpage.PlaceOrder(), Is.EqualTo("Thank you for your purchase!"));

            cartpage.PlaceOrder();
            Assert.That(cartpage.GetOrderConfirmation(),Is.EqualTo("Thank you for your purchase!"));

         


        }

        [Test]
        public void PlaceOrderForLaptop()
        {

            string productname = "Sony vaio i5";
            string menusection = "Laptops";


            HeaderNav headernavigation = new HeaderNav(Driver.current);

            LoginPage loginpage = headernavigation.NavigateToLoginPage();

            HomePage homepage = loginpage.DoLogin("AutomationUser", "happy");

            homepage.clickOnMenu(menusection);
            ProductPage productPage = homepage.SelectItemToView(productname);
            CartPage cartpage = productPage.AddProductToCart();

            Assert.That(cartpage.GetProductNames(), Has.Member(productname));

            //string thankyouheader = cartpage.PlaceOrder();

            //Assert.That(thankyouheader,Is.EqualTo("Thank you for your purchase!"));


            //Assert.That(cartpage.PlaceOrder(), Is.EqualTo("Thank you for your purchase!"));

            cartpage.PlaceOrder();
            Assert.That(cartpage.GetOrderConfirmation(), Is.EqualTo("Thank you for your purchase!"));




        }

    }
}
