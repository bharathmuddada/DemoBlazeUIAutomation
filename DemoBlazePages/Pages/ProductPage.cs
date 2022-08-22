using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazePages.Pages
{
    public class ProductPage : BasePage
    {

        private HeaderNav headernav;
        public ProductPage(IWebDriver driver) : base(driver)
        {
            headernav = new HeaderNav(driver);
        }

        public IWebElement producttitle => driver.FindElement(By.XPath("//h2[@class='name']"));

        public IWebElement AddtoCartbutton => driver.FindElement(By.XPath("//a[text()='Add to cart']"));


        public CartPage AddProductToCart() {
            ClickElement(AddtoCartbutton);
            getAlertText();
            headernav.ClickCartLink();
            return new CartPage(driver);

        }



    }
}
