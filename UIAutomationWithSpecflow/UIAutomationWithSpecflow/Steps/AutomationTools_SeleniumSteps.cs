using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using UIAutomation.PageObjectsAndActions;
using UIAutomation.Utilities;

namespace UIAutomationWithSpecflow.Steps
{
    [Binding]
    public class AutomationTools_SeleniumSteps
    {
        [Given(@"I am in userform page")]
        public void GivenIAmInUserformPage()
        {
            //CommonOperations.TestFixturesetup();
            string header = "User Form";
            Assert.IsTrue(AutomationTools_Selenium.VerifyHeader(header), "Header is invalid");
        }
        
        [When(@"I navigated to selenium webdriver under AutomationTools menu")]
        public void WhenINavigatedToSeleniumWebdriverUnderAutomationToolsMenu()
        {
            MainMenuNavigation.SelectAutomationTools_Function(MainMenuNavigation.AutomationTools_Navigation.Selenium, MainMenuNavigation.Selenium_Navigation.SeleniumWebDriver);

        }

        [Then(@"Selenium Webdriver page should load")]
        public void ThenSeleniumWebdriverPageShouldLoad()
        {
            string header = "Selenium WebDriver";
            Assert.IsTrue(AutomationTools_Selenium.VerifyHeader(header), "Header is invalid");
        }

        [When(@"I navigated to selenium RC under AutomationTools menu")]
        public void WhenINavigatedToSeleniumRCUnderAutomationToolsMenu()
        {
            MainMenuNavigation.SelectAutomationTools_Function(MainMenuNavigation.AutomationTools_Navigation.Selenium, MainMenuNavigation.Selenium_Navigation.SeleniumRC);

        }

        [Then(@"Selenium RC page should load")]
        public void ThenSeleniumRCPageShouldLoad()
        {
            string header = "Selenium RC";
            Assert.IsTrue(AutomationTools_Selenium.VerifyHeader(header), "Header is invalid");
        }
    }
}
