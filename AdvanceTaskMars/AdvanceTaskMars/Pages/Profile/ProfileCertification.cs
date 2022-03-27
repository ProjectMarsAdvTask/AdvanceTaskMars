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
    class ProfileCertification
    {
        private IWebDriver testDriver;
        private static string notificationText;
        public static ExtentTest test;

        //Initialising driver through constructor
        public ProfileCertification(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "ProfileCertification");
        }

        private IWebElement notification => testDriver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        private IWebElement addCertification => testDriver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//thead/tr/th[4]/div"));

        private IWebElement addCertificationBtn => testDriver.FindElement(By.XPath("//input[@value='Add']"));

        private IWebElement updateCertification => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i"));

        private IWebElement updateCertificationBtn => testDriver.FindElement(By.XPath("//input[@value='Update']"));

        private IWebElement deleteCertification => testDriver.FindElement(By.XPath("//i[@class='remove icon']"));

        private IWebElement certificationTextBox1 => testDriver.FindElement(By.Name("certificationName"));

        private IWebElement certificationTextBox2 => testDriver.FindElement(By.Name("certificationFrom"));

        private SelectElement levelDDList => new SelectElement(testDriver.FindElement(By.Name("certificationYear")));

        private IWebElement CertifcationSaved => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));

        public void AddCertificationBtn(IWebDriver testDriver)
        {
            // Click on the "Add new" button of certification
            addCertification.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void AddCertification(IWebDriver testDriver)
        {
            this.testDriver = testDriver;

            // Identify the certification textbox enter valid certification
            WaitHelper.WaitForElementPresent(testDriver, "Name", "certificationName", 2);
            certificationTextBox1.Click();
            //certificationTextBox1.Clear();
            certificationTextBox1.SendKeys(ExcelLibHelpers.ReadData(2, "Certificate"));

            // Identify the certification textbox enter valid certification
            WaitHelper.WaitForElementPresent(testDriver, "Name", "certificationFrom", 2);
            certificationTextBox2.Click();
            //certificationTextBox2.Clear();
            certificationTextBox2.SendKeys(ExcelLibHelpers.ReadData(2, "CertificateFrom"));

            // Identify the year from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "certificationYear", 2);
            levelDDList.SelectByValue(ExcelLibHelpers.ReadData(2, "CertificationYear"));

            // Click on "Add" button
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//input[@value='Add']", 5);
            addCertificationBtn.Click();
        }

        public void ValidateAddCertDetails(IWebDriver testDriver)
        {
            try
            {
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                String Certifcate = CertifcationSaved.Text;
                TestContext.Out.WriteLine(Certifcate);
                notificationText = notification.Text;
                Assert.AreEqual(notificationText, Certifcate + " " + "has been added to your certification");
                test.Log(Status.Pass, "Certifcate has been added successfully");
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
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Certifcate has not been added"));
                }
            }
        }

        public void EditNewCertBtn(IWebDriver testDriver)
        {
            // Click on edit pen icon of the certification
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i", 4);
            updateCertification.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void EditCertification(IWebDriver testDriver)
        {
            this.testDriver = testDriver;

            // Identify the certification textbox enter valid certification
            WaitHelper.WaitForElementPresent(testDriver, "Name", "certificationName", 2);
            certificationTextBox1.Click();
            certificationTextBox1.Clear();
            certificationTextBox1.SendKeys(ExcelLibHelpers.ReadData(3, "Certificate"));

            // Identify the certification textbox enter valid certification
            WaitHelper.WaitForElementPresent(testDriver, "Name", "certificationFrom", 2);
            certificationTextBox2.Click();
            certificationTextBox2.Clear();
            certificationTextBox2.SendKeys(ExcelLibHelpers.ReadData(3, "CertificateFrom"));

            // Identify the year from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "certificationYear", 2);
            levelDDList.SelectByValue(ExcelLibHelpers.ReadData(3, "CertificationYear"));

            // Click on "Add" button
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//input[@value='Update']", 5);
            updateCertificationBtn.Click();
        }

        public void ValidateEditCertDetails(IWebDriver testDriver)
        {
            try
            {
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                String Certifcate = CertifcationSaved.Text;
                TestContext.Out.WriteLine(Certifcate);
                notificationText = notification.Text;
                Assert.AreEqual(notificationText, "ISTQB - CTFL has been updated to your certification");
                test.Log(Status.Pass, "Certifcate has been updated successfully");
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
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Certifcate has not been updated"));
                }
            }
        }

        public void DeleteNewCertBtn(IWebDriver testDriver)
        {
            // Click on the "Delete" button of certification
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//i[@class='remove icon']", 4);
            deleteCertification.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void ValidateDeleteCertDetails(IWebDriver testDriver)
        {
            try
            {
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                String Certifcate = CertifcationSaved.Text;
                TestContext.Out.WriteLine(Certifcate);
                notificationText = notification.Text;
                Assert.AreEqual(notificationText, Certifcate + " " + "has been deleted from your certification");
                test.Log(Status.Pass, "Certifcate has been deleted successfully");
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
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Certifcate has not been deleted"));
                }
            }
        }
    }
}
