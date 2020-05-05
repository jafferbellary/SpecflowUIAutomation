using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.Utilities
{
    class CommonOperations
    {
        //private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void TestFixturesetup()
        {
            var resultlocation = getnormalizedLocation("resultlocation");
            var downloadFolder = ConfigurationManager.AppSettings["browserDownloadfolder"];

            clearDirectory(downloadFolder);
            //log.Info("Successfully cleared the download folder");
            //TestStartup.getUserPwdAndEnv();
            var folderForScreenshot = Path.Combine(resultlocation, getday());
            Console.WriteLine("folderForScreenshot : " + folderForScreenshot);
            Directory.CreateDirectory(folderForScreenshot);
            Console.WriteLine("folderForScreenshot : " + folderForScreenshot);
            //log.Info("folderForScreenshot : " + folderForScreenshot);
            LoginPage.login();
        }

        public static void TestFixtureteardown()
        {
            if (Globalclass.driver != null)
            {
                Globalclass.driver.Quit();
            }
        }

        public static void TestFixtureteardown1()
        {
            if (Globalclass.driver != null)
            {
                //ReportResultUtility.EndReportResultString();
                //ReportResultUtility.WriteToHtmlFile(ReportResultUtility.reportResultHtmlString.ToString(), Globalclass.resultlocation + ".html");
                Globalclass.driver.Quit();
            }
        }

        public static void TestTeardown()
        {
            var resultlocation = getnormalizedLocation("resultlocation");
            if (TestContext.CurrentContext.Result.Outcome.ToString().Equals("Failed"))
            {
                Screenshot ss = ((ITakesScreenshot)Globalclass.driver).GetScreenshot();
                var saveScreenshotInToFolder = Globalclass.resultlocation + ".jpeg";
                ss.SaveAsFile(saveScreenshotInToFolder, ScreenshotImageFormat.Jpeg);
                //ReportResultUtility.EndReportResultString();
                //ReportResultUtility.WriteToHtmlFile(ReportResultUtility.reportResultHtmlString.ToString(), Globalclass.resultlocation + ".html");
                Globalclass.driver.Quit();
                Globalclass.driver = null;
            }
        }

        public static void testsetup()
        {
            if (Globalclass.driver == null)
            {
                //log.Info("Launching application again!!!");
                LoginPage.login();
            }
        }

        public static String getnormalizedLocation(string appConfigString)
        {
            var projectlocation = Environment.CurrentDirectory;
            var folder = ConfigurationManager.AppSettings[appConfigString];
            var location = projectlocation.Replace(@"\bin\Debug", "");
            return (Path.Combine(location, folder));
        }

        public static void clearDirectory(String path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            foreach (FileInfo file in d.GetFiles())
            {
                file.Delete();
            }
        }

        public static String getday()
        {
            var date = DateTime.Now;
            return (date.Day + "" + date.Month + "" + date.Year).ToString();
        }

        public static void CreateReportForTestMethod(String testMethod)
        {
            var resultlocation = getnormalizedLocation("resultlocation");
            var folderForScreenshot = Path.Combine(resultlocation, getday());
            folderForScreenshot = Path.Combine(folderForScreenshot, testMethod);
            Directory.CreateDirectory(folderForScreenshot);
            Globalclass.resultlocation = Path.Combine(folderForScreenshot, testMethod);
        }

        public static string GetEnumDescription(object enumvalue)
        {
            FieldInfo f = enumvalue.GetType().GetField(enumvalue.ToString());
            if (null != f)
            {
                object[] attrs = f.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((System.ComponentModel.DescriptionAttribute)attrs[0]).Description;
                }
            }
            return null;
        }
    }
}
