using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UIAutomation.Utilities;

namespace UIAutomationWithSpecflow.Utilities
{
    [Binding]
    class Hooks
    {
        [BeforeTestRun]
        public static void setup()
        {
            ExtentReport.BeforeClass();
            CommonOperations.TestFixturesetup();
        }

        [AfterTestRun]
        public static void teardown()
        {
            ExtentReport.AfterClass();
            CommonOperations.TestFixtureteardown1();
        }

        [BeforeScenario]
        public static void testSetup()
        {
            //ExtentReport.BeforeTest();
            ExtentReport.BeforeScenario();
            CommonOperations.testsetup();
        }

        [AfterScenario]
        public static void testTeardown()
        {
            ExtentReport.AfterTest();
            CommonOperations.TestTeardown();
        }

        [BeforeFeature]
        public static void beforeFeature()
        {
            ExtentReport.BeforeFeature();
        }

        [AfterStep]
        public static void insertReportingSteps()
        {
            ExtentReport.InsertReportingSteps();
        }






        //public class Hooks
        //{
        //    private readonly FeatureContext _featureContext;
        //    private readonly ScenarioContext _scenarioContext;
        //    private ExtentTest _currentScenarioName;

        //    private static ExtentTest featureName;
        //    public static ExtentTest scenario;
        //    private static ExtentReports extent;

        //    public Hooks(FeatureContext featureContext, ScenarioContext scenarioContext)
        //    {
        //        _featureContext = featureContext;
        //        _scenarioContext = scenarioContext;
        //    }

        //    [BeforeTestRun]
        //    public static void setup()
        //    {
        //        extent = new ExtentReports();
        //        var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
        //        DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
        //        var htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + ".html");
        //        extent.AddSystemInfo("Environment", "DEV");
        //        extent.AddSystemInfo("User Name", "Jaffer");
        //        extent.AttachReporter(htmlReporter);

        //        CommonOperations.TestFixturesetup();
        //    }

        //    [AfterTestRun]
        //    public static void teardown()
        //    {
        //        extent.Flush();
        //        CommonOperations.TestFixtureteardown1();
        //    }

        //    [BeforeScenario]
        //    public void testSetup()
        //    {
        //        //ExtentReport.BeforeTest();
        //        scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        //        CommonOperations.testsetup();
        //    }

        //    [AfterScenario]
        //    public static void testTeardown()
        //    {
        //        //ExtentReport.AfterTest();
        //        CommonOperations.TestTeardown();
        //    }

        //    [BeforeFeature]
        //    public static void beforeFeature()
        //    {
        //        featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
        //        //featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
        //    }

        //    [AfterStep]
        //    public void AfterEachStep()
        //    {
        //        var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

        //        if (_scenarioContext.TestError == null)
        //        {
        //            if (stepType == "Given")
        //                _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
        //            else if (stepType == "When")
        //                _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
        //            else if (stepType == "Then")
        //                _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
        //            else if (stepType == "And")
        //                _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
        //        }

        //        else if (_scenarioContext.TestError != null)
        //        {
        //            //Screenshot in the Base 64 format
        //            var mediaEntity = CaptureScreenshotAndReturnModel(_scenarioContext.ScenarioInfo.Title.Trim());

        //            if (stepType == "Given")
        //                _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
        //            else if (stepType == "When")
        //                _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
        //            else if (stepType == "Then")
        //                _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
        //            else if (stepType == "And")
        //                _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
        //        }
        //        else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
        //        {
        //            if (stepType == "Given")
        //                _currentScenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
        //            else if (stepType == "When")
        //                _currentScenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
        //            else if (stepType == "Then")
        //                _currentScenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
        //        }
        //    }

        //    public static MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        //    {
        //        var screenshot = ((ITakesScreenshot)Globalclass.driver).GetScreenshot().AsBase64EncodedString;
        //        return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();
        //    }
    }
}
