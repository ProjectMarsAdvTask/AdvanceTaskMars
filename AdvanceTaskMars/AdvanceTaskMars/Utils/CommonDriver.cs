using AdvanceTaskMars.Config;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using static AdvanceTaskMars.Utils.CommonMethods;

namespace AdvanceTaskMars.Utils
{
    [SetUpFixture]
    class CommonDriver
    {
        public IWebDriver testDriver;
        public static string BaseUrlPath = MarsResource.BaseUrl;

        protected ExtentTest test;
        protected ExtentReports extent;

        [OneTimeSetUp]
        protected void Setup()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = (projectPath + "Reports\\ExtentReport.html");
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "LocalHost");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("UserName", "JiaLe");
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            extent.Flush();
        }

        [SetUp]
        public void SetUpBrowser()
        {
            testDriver = new ChromeDriver();
            testDriver.Navigate().GoToUrl(BaseUrlPath);
            testDriver.Manage().Window.Maximize();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            testDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
        }

        [TearDown]
        public void CloseBrowser()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    //String screenShotPath = SaveScreenShotClass.SaveScreenshot1(testDriver, fileName);
                    String screenShotPath = SaveScreenShotClass.SaveScreenshot1(testDriver, fileName);
                    var screenShotPath1 = SaveScreenShotClass.SaveScreenshot2(testDriver, fileName);
                    test.Log(Status.Fail, "Fail");
                    test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    test.Pass("ExtentReport 4 Capture: Test Failed", screenShotPath1);
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    DateTime time1 = DateTime.Now;
                    String fileName1 = "Screenshot_" + time1.ToString("h_mm_ss") + ".png";
                    //String screenShotPath3 = SaveScreenShotClass.SaveScreenshot1(testDriver, fileName1);
                    String screenShotPath3 = SaveScreenShotClass.SaveScreenshot1(testDriver, fileName1);
                    var screenShotPath2 = SaveScreenShotClass.SaveScreenshot2(testDriver, fileName1);
                    test.Log(Status.Pass, "Pass");
                    test.Log(Status.Pass, "Snapshot below: " + test.AddScreenCaptureFromPath("Screenshots\\" + fileName1));
                    test.Pass("ExtentReport 4 Capture: Test Passed", screenShotPath2);
                    break;
            }
            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            extent.Flush();
            testDriver.Quit();
        }
    }
}
