using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.Utilities
{
    class Globalclass
    {
        public static IWebDriver driver;
        public static String resultlocation;

        public static String envToTest = "DEV";
        public static String ssoUserName = "Name";
        public static String ssoPassword = "Password";
    }
}
