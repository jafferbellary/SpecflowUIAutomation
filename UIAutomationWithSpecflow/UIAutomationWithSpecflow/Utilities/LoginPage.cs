using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.Utilities
{
    class LoginPage
    {
        //private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static IWebElement userName_TextObject;
        private static IWebElement password_TextObject;
        private static IWebElement login_ButtonObject;

        public static Boolean login()
        {
            try
            {
                var url = ConfigurationManager.AppSettings[Globalclass.envToTest];
                //var url = ConfigurationManager.AppSettings["DEV"];
                BrowserOperations.LoadDriver(url);

                userName_TextObject = Globalclass.driver.FindElement(By.Name("UserName"));
                userName_TextObject.Click();
                userName_TextObject.SendKeys(Globalclass.ssoUserName);

                password_TextObject = Globalclass.driver.FindElement(By.Name("Password"));
                password_TextObject.Click();
                password_TextObject.SendKeys(Globalclass.ssoPassword);

                login_ButtonObject = Globalclass.driver.FindElement(By.XPath(".//input[contains(@type, 'submit')]"));
                login_ButtonObject.Click();

                BrowserOperations.waitTillBrowserLoads();
                return true;
            }
            catch (Exception e)
            {
                //log.Info(e.Message);
                return false;
            }
        }
    }
}
