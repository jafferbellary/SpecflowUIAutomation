using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Utilities;

namespace UIAutomation.PageObjectsAndActions
{
    class AutomationTools_Selenium
    {
        public static Boolean VerifyHeader(string header)
        {
            IWebElement element = Globalclass.driver.FindElement(By.TagName("h2"));
            if (element.Text.Equals(header))
            {
                //ReportResultUtility.AddTestPassToReportResultString("Successfully verified " + element.Text + " header", "Pass");
                return true;
            }
            //ReportResultUtility.AddTestFailToReportResultString("Unble to verify the  header", "Fail");
            return false;
        }
    }
}
