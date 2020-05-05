using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UIAutomation.Utilities
{
    class MainMenuNavigation
    {
        public enum AutomationTools_Navigation
        {
            [Description("Selenium")]
            Selenium,
            [Description("BDD")]
            BDD
        };

        public enum Selenium_Navigation
        {
            [Description("Selenium WebDriver")]
            SeleniumWebDriver,
            [Description("Selenium RC")]
            SeleniumRC,
            [Description("Selenium IDE")]
            SeleniumIDE
        };

        public enum BDD_Navigation
        {
            [Description("Specflow")]
            Specflow,
            [Description("Cucumber")]
            Cucumber
        };

        private static void clickMenuItem(String menuItem)
        {
            BrowserOperations.waitTillBrowserLoads();
            IWebElement menu = Globalclass.driver.FindElement(By.XPath(""));
            menu.FindElement(By.LinkText(menuItem)).Click();
            BrowserOperations.waitTillBrowserLoads();
            Thread.Sleep(1000);
        }

        private static IWebElement getMenu(String nameOfMenu)
        {
            BrowserOperations.waitTillBrowserLoads();
            IList<IWebElement> menus = Globalclass.driver.FindElements(By.TagName("span"));
            foreach (IWebElement menu in menus)
            {
                if (menu.Text.Equals(nameOfMenu))
                {
                    return menu;
                }
            }
            return null;
        }

        public static void SelectAutomationTools_Function(AutomationTools_Navigation function, Selenium_Navigation submenu)
        {
            getMenu("AUTOMATION TOOLS").Click();
            clickMenuItem1(CommonOperations.GetEnumDescription(function), CommonOperations.GetEnumDescription(submenu));
        }

        public static void SelectMainMenu_Function(String menu)
        {
            getMenu(menu).Click();
        }

        private static void clickMenuItem1(String menuItem, String submenuItem)
        {
            BrowserOperations.waitTillBrowserLoads();
            IWebElement menu = Globalclass.driver.FindElement(By.ClassName("has-sub"));
            menu.FindElement(By.LinkText(menuItem)).Click();
            Thread.Sleep(2500);
            IWebElement subMenu = Globalclass.driver.FindElement(By.ClassName("has-sub"));
            subMenu.FindElement(By.LinkText(submenuItem)).Click();
            BrowserOperations.waitTillBrowserLoads();
            Thread.Sleep(1000);
        }
    }
}
