Feature: AutomationTools_Selenium
	

@Regressiontest
Scenario: Selenium WebDriver Verification
	Given I am in userform page
	When I navigated to selenium webdriver under AutomationTools menu
	Then Selenium Webdriver page should load


@Regressiontest
Scenario: Selenium RC Verification
	Given I am in userform page
	When I navigated to selenium RC under AutomationTools menu
	Then Selenium RC page should load
