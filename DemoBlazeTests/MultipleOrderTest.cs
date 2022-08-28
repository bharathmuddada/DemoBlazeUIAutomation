using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazeTests
{
    [Parallelizable]
    [AllureNUnit]
    [AllureSuite("DemoBlazeUI - Multiple Tests")]
    public class MultipleOrderTest : BaseTest
    {   
        [Test]
        [Retry(1)]
        [AllureName(name: "Order phones and laptops")]
        public void OrderMultipleProducts() {


            string productname = "Samsung galaxy s6";
            string menusection = "Phones";
            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.NavigateToLoginPage();

            HomePage homepage = loginpage.DoLogin("AutomationUser",
                "happy");

            homepage.clickOnMenu(menusection);
            ProductPage productPage = homepage.SelectItemToView(productname);
            CartPage cartpage = productPage.AddProductToCart();

            headerBar.NavigateToHomePage();
            homepage.clickOnMenu("Laptops")
                    .SelectItemToView("Sony vaio i5")
                    .AddProductToCart();

            List<string> expectedProdNameList = new List<string> { "Sony vaio i5", "Samsung galaxy s6" };
            
            Assert.That(cartpage.GetProductNames(), Is.EquivalentTo(expectedProdNameList));

        }


        [Test]
        [Retry(1)]
        [AllureName(name: "Validate the cart total with product prices")]
        public void ValidateCartTotal()
        {


            string productname = "Samsung galaxy s6";
            string menusection = "Phones";
            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.NavigateToLoginPage();

            HomePage homepage = loginpage.DoLogin("AutomationUser",
                "happy");

            homepage.clickOnMenu(menusection);
            ProductPage productPage = homepage.SelectItemToView(productname);
            CartPage cartpage = productPage.AddProductToCart();

            headerBar.NavigateToHomePage();
            homepage.clickOnMenu("Laptops")
                    .SelectItemToView("Sony vaio i5")
                    .AddProductToCart();

            List<string> expectedProdNameList = new List<string> { "Sony vaio i5", "Samsung galaxy s6" };

            Assert.That(cartpage.GetProductNames(), Is.EquivalentTo(expectedProdNameList));

            Console.WriteLine($"Total price of the cart is {cartpage.TotalCartPrice.Text}");

            Assert.That(cartpage.SumOfProductPrices(), Is.EqualTo(int.Parse(cartpage.TotalCartPrice.Text)));


        }

        [Test]
        [Retry(1)]
        [AllureName(name: "Validate the Price in the order confirmation")]
        public void ValidateOrderConfirmationPrice()
        {


            string productname = "Samsung galaxy s6";
            string menusection = "Phones";
            var headerBar = new HeaderNav(Driver.current);

            LoginPage loginpage = headerBar.NavigateToLoginPage();

            HomePage homepage = loginpage.DoLogin("AutomationUser",
                "happy");

            homepage.clickOnMenu(menusection);
            ProductPage productPage = homepage.SelectItemToView(productname);
            CartPage cartpage = productPage.AddProductToCart();

            headerBar.NavigateToHomePage();
            homepage.clickOnMenu("Laptops")
                    .SelectItemToView("Sony vaio i5")
                    .AddProductToCart();

            List<string> expectedProdNameList = new List<string> { "Sony vaio i5", "Samsung galaxy s6" };

            Assert.That(cartpage.GetProductNames(), Is.EquivalentTo(expectedProdNameList));

            Console.WriteLine($"Total price of the cart is {cartpage.TotalCartPrice.Text}");

            cartpage.PlaceOrder();

            Assert.That(cartpage.PriceFromOrderConfirmation(), Is.EqualTo(int.Parse(cartpage.TotalCartPrice.Text)));


        }

    }
}
