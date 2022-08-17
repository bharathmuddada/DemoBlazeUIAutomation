using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazePages.Pages
{
    public class BasePage
    {
        public HeaderBar HeaderBar;
        public BasePage(IWebDriver driver) { 
                
            HeaderBar = new HeaderBar(driver);
        
        }
    }
}
