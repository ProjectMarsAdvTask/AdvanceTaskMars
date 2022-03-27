using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AdvanceTaskMars.Pages
{
    class Notification
    {
        private IWebDriver testDriver;
        public static ExtentTest test;

        public Notification(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
        }

        private IWebElement Dashboard => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[1]"));

        private IWebElement LoadMore => testDriver.FindElement(By.XPath("//*[@id='notification-section']//center/a[text()='Load More...']"));

        private IWebElement ShowLess => testDriver.FindElement(By.XPath("//*[@id='notification-section']//center/a[text()='...Show Less']"));

        private IList<IWebElement> ServiceRequestRows => testDriver.FindElements(By.TagName("hr"));

        public void NotifyDashBoardPage()
        {
            //test.Log(Status.Info, "Navigate to the Dashboard");
            //testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Dashboard.Click();
            WaitHelper.WaitForElementPresent(testDriver, "Xpath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1", 2);
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void ValidateLoadMore()
        {
            try
            {
                // Click on the Load more button until Load more button is visible
                while (LoadMore.Displayed)
                {
                    LoadMore.Click();
                    testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    WaitHelper.WaitForElementPresent(testDriver, "Xpath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1", 2);
                    test.Log(Status.Info, "Load More button is clicked");
                }
            }
            catch (NoSuchElementException)
            {
                test.Log(Status.Pass, "All the data is shown");
            }

            catch (Exception)
            {
                Assert.Fail("System Error");
                test.Log(Status.Fail, "System Error");
            }
            finally
            {
                Assert.Pass("All the data is shown");
                test.Log(Status.Pass, "All the data is shown");
            }
        }

        public void ValidateShowLess()
        {
            try
            {
                //Click on the Show Less button untill Show Less button is visible
                while (ShowLess.Displayed)
                {
                    ShowLess.Click();
                    testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    WaitHelper.WaitForElementPresent(testDriver, "Xpath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1", 2);
                    test.Log(Status.Info, "Show Less button is clicked");
                }
            }
            catch (NoSuchElementException)
            {
                test.Log(Status.Pass, "All the data is shown");
            }

            catch (Exception)
            {
                Assert.Fail("System Error");
                test.Log(Status.Fail, "System Error");
            }
            finally
            {
                Assert.Pass("All the data is shown");
                test.Log(Status.Pass, "All the data is shown");
            }
        }
    }
}
