using AdvanceTaskMars.Config;
using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AdvanceTaskMars.Pages.Profile
{
    class ProfileLanguage
    {
        private IWebDriver testDriver;
        private static string notificationText;
        public static ExtentTest test;

        //Initialising driver through constructor
        public ProfileLanguage(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "ProfileLanguage");
        }
        private IWebElement addLanguage => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));

        private IWebElement languageTextBox => testDriver.FindElement(By.Name("name"));

        private IWebElement editLanguage => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));

        private IWebElement deleteLanguage => testDriver.FindElement(By.XPath("//i[@class='remove icon']"));

        private SelectElement levelDDList => new SelectElement(testDriver.FindElement(By.Name("level")));

        private IWebElement addLanguageBtn => testDriver.FindElement(By.XPath("//input[@value='Add']"));

        private IWebElement notification => testDriver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        private IWebElement savedName => testDriver.FindElement(By.CssSelector("tbody tr td:nth-child(1)"));

        private IWebElement updateBtn => testDriver.FindElement(By.XPath("//input[@value='Update']"));

        //Add Language
        public void AddLanguageBtn(IWebDriver driver)
        {
            this.testDriver = driver;
            // Click on the "Add new" button of language
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 4);
            addLanguage.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void AddLanguageDetails(IWebDriver testDriver)
        {
            this.testDriver = testDriver;

            // Identify the language textbox enter valid language
            WaitHelper.WaitForElementPresent(testDriver, "Name", "name", 2);
            languageTextBox.Click();
            languageTextBox.SendKeys(ExcelLibHelpers.ReadData(2, "Language"));

            // Identify the level from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "level", 2);
            levelDDList.SelectByValue(ExcelLibHelpers.ReadData(2, "Level"));

            // Click on "Add" button
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//input[@value='Add']", 5);
            addLanguageBtn.Click();
        }

        public void ValidateAddLanguageDetails(IWebDriver testDriver)
        {
            try
            {
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                String Language = savedName.Text;
                TestContext.Out.WriteLine(Language);
                notificationText = notification.Text;
                Assert.AreEqual(notificationText, Language + " " + "has been added to your languages");
                test.Log(Status.Pass, "Language has been added successfully");
            }
            catch
            {
                var NotificationText = notification.Text;
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;

                if (status == TestStatus.Failed)
                {
                    test.Log(Status.Fail, "Error Message :" + NotificationText);
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Language has not been added"));
                }
            }
        }

        public void EditLanguageBtn(IWebDriver driver)
        {
            this.testDriver = driver;
            // Click on the edit pen icon button of language
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 4);
            editLanguage.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void EditLanguageDetails(IWebDriver testDriver)
        {
            this.testDriver = testDriver;

            // Identify the language textbox enter valid language
            WaitHelper.WaitForElementPresent(testDriver, "Name", "name", 2);
            languageTextBox.Click();
            languageTextBox.Clear();
            languageTextBox.SendKeys(ExcelLibHelpers.ReadData(3, "Language"));

            // Identify the level from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "level", 2);
            levelDDList.SelectByValue(ExcelLibHelpers.ReadData(3, "Level"));

            // Click on "Update" button
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//input[@value='Update']", 5);
            updateBtn.Click();
        }

        public void ValidateEditLanguageDetails(IWebDriver testDriver)
        {
            try
            {
                this.testDriver = testDriver;
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                String Language = savedName.Text;
                //NotificationText = Notification.Text;
                Assert.AreEqual(notification.Text, "Japanese has been updated to your languages");
                test.Log(Status.Pass, "Language has been updated successfully");
            }
            catch
            {
                var NotificationText = notification.Text;
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;

                if (status == TestStatus.Failed)
                {
                    test.Log(Status.Fail, "Error Message :" + NotificationText);
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Language has not been updated"));
                }
            }
        }

        public void DeleteLanguageDetails(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            // Click on the "Delete" button of language
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i", 4);
            deleteLanguage.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void ValidateDeleteLanguageDetails(IWebDriver testDriver)
        {
            try
            {
                this.testDriver = testDriver;
                WaitHelper.WaitForElementPresent(testDriver, "CssSelector", "tbody tr td:nth-child(1)", 2);
                String Language = savedName.Text;
                notificationText = notification.Text;
                Assert.AreEqual(notification.Text, Language + " " + "has been deleted from your languages");
                test.Log(Status.Pass, "Language has been deleted successfully");
            }
            catch
            {
                var NotificationText = notification.Text;
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;

                if (status == TestStatus.Failed)
                {
                    test.Log(Status.Fail, "Error Message :" + NotificationText);
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Language has not been deleted"));
                }
            }
        }
    }
}
