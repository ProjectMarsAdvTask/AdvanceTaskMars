using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Text;

namespace AdvanceTaskMars.Utils
{
    class CommonMethods
    {
        // screenshots
        public class SaveScreenShotClass
        {
            public static IWebDriver driver { get; set; }

            public static string SaveScreenshot1(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = AppDomain.CurrentDomain.BaseDirectory;

                Directory.CreateDirectory(folderLocation + "Screenshots");
                TestContext.WriteLine(folderLocation);

                var finalpth = folderLocation.Substring(0, folderLocation.LastIndexOf("bin")) + "Screenshots\\";
                var localpath = new Uri(finalpth).LocalPath;
                if (!System.IO.Directory.Exists(localpath))
                {
                    System.IO.Directory.CreateDirectory(localpath);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(localpath);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                fileName.Append(".Png");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Png);
                return fileName.ToString();
            }

            public static MediaEntityModelProvider SaveScreenshot2(IWebDriver driver, String screenShotName)
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                var screenshot = ts.GetScreenshot().AsBase64EncodedString;

                return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
            }
        }
    }
}
