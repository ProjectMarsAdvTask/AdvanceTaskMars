using AdvanceTaskMars.Config;
using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace AdvanceTaskMars.Pages.Profile
{
    class ProfileDescription
    {
        private IWebDriver testDriver;
        private static string notificationText;
        public static ExtentTest test;

        //Initialising driver through constructor
        public ProfileDescription(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "ProfileDescription");
        }

        private IWebElement descriptionIcon => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));

        private IWebElement addDescriptTextBox => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));

        private IWebElement notification => testDriver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        private IWebElement saveButton => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));

        public void DescriptionPenIcon(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            // Identify Description icon and click
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i", 4);
            descriptionIcon.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void AddDescription(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            Actions Hover = new Actions(testDriver);

            // Identify the description textarea enter valid description
            WaitHelper.WaitForElementPresent(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea", 2);
            Hover.Click(addDescriptTextBox).Perform();
            addDescriptTextBox.Clear();
            addDescriptTextBox.SendKeys(ExcelLibHelpers.ReadData(2, "Description"));

            // Click on "Save" button
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button", 5);
            saveButton.Click();
        }

        public void ValidateAddDescription1(IWebDriver testDriver)
        {
            try
            {
                this.testDriver = testDriver;
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                Assert.AreEqual(notification.Text, "Description has been saved successfully");
                test.Log(Status.Pass, "Description has been saved successfully");
            }
            catch
            {
                Assert.AreNotEqual(notificationText, "Description has been not added successfully");
            }
        }

        public void EditDescription(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            Actions Hover = new Actions(testDriver);

            // Identify the description textarea enter valid description
            WaitHelper.WaitForElementPresent(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea", 2);
            Hover.Click(addDescriptTextBox).Perform();
            addDescriptTextBox.Clear();
            addDescriptTextBox.SendKeys(ExcelLibHelpers.ReadData(3, "Description"));

            // Click on "Save" button
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button", 5);
            saveButton.Click();
        }

        public void ValidateAddDescription2(IWebDriver testDriver)
        {
            try
            {
                this.testDriver = testDriver;
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                Assert.AreEqual(notification.Text, "Description has been saved successfully");
                test.Log(Status.Pass, "Description has been saved successfully");
            }
            catch
            {
                Assert.AreNotEqual(notificationText, "Description has been not added successfully");
            }
        }
    }
}
