using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazePages.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement productname => driver.FindElement(By.XPath("//*[@id='tbodyid']/tr[1]/td[2]"));


        public string GetProductName() {

            WaitForElementTobeDisplayed(productname);

            return productname.Text;
        }

    }
}
