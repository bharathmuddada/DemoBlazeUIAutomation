using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazeTests
{
    public class TestData
    {

        public static TestCaseData[] OrdersTestData()
        {

            return new TestCaseData[]{

                new TestCaseData("Phones","Samsung galaxy s6"),
                new TestCaseData("Laptops","Sony vaio i5"),
                //new TestCaseData("Monitors","Apple monitor 24")


            };

        }
    }
}
