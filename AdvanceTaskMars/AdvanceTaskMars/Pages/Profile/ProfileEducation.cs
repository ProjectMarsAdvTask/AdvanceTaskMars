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
    class ProfileEducation
    {
        private IWebDriver testDriver;
        private static string notificationText;
        public static ExtentTest test;

        //Initialising driver through constructor
        public ProfileEducation(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "ProfileEducation");
        }

        private IWebElement addEducation => testDriver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//thead/tr/th[6]/div"));

        private IWebElement notification => testDriver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        private IWebElement UniversityNameTextBox => testDriver.FindElement(By.Name("instituteName"));

        private SelectElement countryLvlDDList => new SelectElement(testDriver.FindElement(By.Name("country")));

        private SelectElement titleLvlDDList => new SelectElement(testDriver.FindElement(By.Name("title")));

        private IWebElement degreeTextBox => testDriver.FindElement(By.Name("degree"));

        private SelectElement yearLvlDDList => new SelectElement(testDriver.FindElement(By.Name("yearOfGraduation")));

        private IWebElement addEducationBtn => testDriver.FindElement(By.XPath("//input[@value='Add']"));

        private IWebElement updateEducation => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));

        private IWebElement updateEducationBtn => testDriver.FindElement(By.XPath("//input[@value='Update']"));

        private IWebElement deleteEducation => testDriver.FindElement(By.XPath("//i[@class='remove icon']"));

        public void AddNewEducationBtn(IWebDriver testDriver)
        {
            // Click on the "Add new" button of education
            //WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 4);
            addEducation.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void AddEducation(IWebDriver testDriver)
        {
            this.testDriver = testDriver;

            // Identify the university name textbox enter valid university name
            WaitHelper.WaitForElementPresent(testDriver, "Name", "instituteName", 2);
            UniversityNameTextBox.Click();
            UniversityNameTextBox.SendKeys(ExcelLibHelpers.ReadData(2, "UniversityName"));

            // Identify the country of university from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "country", 2);
            countryLvlDDList.SelectByValue(ExcelLibHelpers.ReadData(2, "Country"));

            // Identify the title from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "title", 2);
            titleLvlDDList.SelectByValue(ExcelLibHelpers.ReadData(2, "UniversityTitle"));

            // Identify the degree textbox enter valid degree
            WaitHelper.WaitForElementPresent(testDriver, "Name", "degree", 2);
            degreeTextBox.Click();
            degreeTextBox.SendKeys(ExcelLibHelpers.ReadData(2, "Degree"));

            // Identify the graduation year from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "yearOfGraduation", 2);
            yearLvlDDList.SelectByValue(ExcelLibHelpers.ReadData(2, "Year"));

            // Click on "Add" button
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//input[@value='Add']", 5);
            addEducationBtn.Click();
        }

        public void ValidateAddEducationDetails(IWebDriver testDriver)
        {
            try
            {
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                notificationText = notification.Text;
                Assert.AreEqual(notificationText, "Education has been added");
                test.Log(Status.Pass, "Education has been added successfully");
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
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Education has not been added"));
                }
            }
        }

        public void EditEducationBtn(IWebDriver testDriver)
        {
            // Click on edit pen icon of the education
            //WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i", 4);
            updateEducation.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void EditEducation(IWebDriver testDriver)
        {
            this.testDriver = testDriver;

            // Identify the university name textbox enter valid university name
            WaitHelper.WaitForElementPresent(testDriver, "Name", "instituteName", 2);
            UniversityNameTextBox.Click();
            UniversityNameTextBox.Clear();
            UniversityNameTextBox.SendKeys(ExcelLibHelpers.ReadData(3, "UniversityName"));

            // Identify the country of university from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "country", 2);
            countryLvlDDList.SelectByValue(ExcelLibHelpers.ReadData(3, "Country"));

            // Identify the title from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "title", 2);
            titleLvlDDList.SelectByValue(ExcelLibHelpers.ReadData(3, "UniversityTitle"));

            // Identify the degree textbox enter valid degree
            WaitHelper.WaitForElementPresent(testDriver, "Name", "degree", 2);
            degreeTextBox.Click();
            degreeTextBox.Clear();
            degreeTextBox.SendKeys(ExcelLibHelpers.ReadData(3, "Degree"));

            // Identify the graduation year from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "yearOfGraduation", 2);
            yearLvlDDList.SelectByValue(ExcelLibHelpers.ReadData(3, "Year"));

            // Click on "Add" button
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//input[@value='Update']", 5);
            updateEducationBtn.Click();
        }

        public void ValidateEditEducationDetails(IWebDriver testDriver)
        {
            try
            {
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                notificationText = notification.Text;
                Assert.AreEqual(notificationText, "Education as been updated");
                test.Log(Status.Pass, "Education has been updated successfully");
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
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Education has not been updated"));
                }
            }
        }

        public void DeleteEducationBtn(IWebDriver testDriver)
        {
            // Click on the "Delete" button of language
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//i[@class='remove icon']", 4);
            deleteEducation.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void ValidateDeleteEducationDetails(IWebDriver testDriver)
        {
            try
            {
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                notificationText = notification.Text;
                Assert.AreEqual(notification.Text, "Education entry successfully removed");
                test.Log(Status.Pass, "Education has been deleted successfully");
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
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Education entry unsuccessfully removed"));
                }
            }
        }
    }
}
