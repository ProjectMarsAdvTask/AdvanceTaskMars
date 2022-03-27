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
    class ProfileSkill
    {
        private IWebDriver testDriver;
        private static string notificationText;
        public static ExtentTest test;

        //Initialising driver through constructor
        public ProfileSkill(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "ProfileSkill");
        }
        private IWebElement notification => testDriver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        private IWebElement addSkill => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));

        private IWebElement skillSaved => testDriver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//tbody[1]/tr[1]/td[1]"));

        private IWebElement editSkill => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));

        private IWebElement addSkillBtn => testDriver.FindElement(By.XPath("//input[@value='Add']"));

        private IWebElement updateSkillBtn => testDriver.FindElement(By.XPath("//input[@value='Update']"));

        private IWebElement deleteSkill => testDriver.FindElement(By.XPath("//i[@class='remove icon']"));

        private IWebElement skillsTextBox => testDriver.FindElement(By.Name("name"));

        private SelectElement levelDDList => new SelectElement(testDriver.FindElement(By.Name("level")));

        public void AddNewSkillsBtn(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            // Click on the "Add new" button of skills
            addSkill.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void AddSkills(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            // Identify the skills textbox enter valid skills
            WaitHelper.WaitForElementPresent(testDriver, "Name", "name", 2);
            skillsTextBox.Click();
            skillsTextBox.SendKeys(ExcelLibHelpers.ReadData(2, "Skill"));

            // Identify the level from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "level", 2);
            levelDDList.SelectByValue(ExcelLibHelpers.ReadData(2, "SkillLevel"));

            // Click on "Add" button
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//input[@value='Add']", 5);
            addSkillBtn.Click();
        }

        public void ValidateAddSkillDetails(IWebDriver testDriver)
        {
            try
            {
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                String Skill = skillSaved.Text;
                TestContext.Out.WriteLine(Skill);
                notificationText = notification.Text;
                Assert.AreEqual(notificationText, Skill + " " + "has been added to your skills");
                test.Log(Status.Pass, "Skill has been added successfully");
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
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Skill has not been added"));
                }
            }
        }

        public void EditSkillBtn(IWebDriver driver)
        {
            this.testDriver = driver;
            // Click on the "Add new" button of skill
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]", 4);
            editSkill.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void EditSkill(IWebDriver testDriver)
        {
            this.testDriver = testDriver;

            // Identify the skills textbox enter valid skills
            WaitHelper.WaitForElementPresent(testDriver, "Name", "name", 2);
            skillsTextBox.Click();
            skillsTextBox.Clear();
            skillsTextBox.SendKeys(ExcelLibHelpers.ReadData(3, "Skill"));

            // Identify the level from the dropdown list
            WaitHelper.WaitForElementPresent(testDriver, "Name", "level", 2);
            levelDDList.SelectByValue(ExcelLibHelpers.ReadData(3, "SkillLevel"));

            // Click on "Update" button
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//input[@value='Update']", 5);
            updateSkillBtn.Click();
        }

        public void ValidateEditSkillDetails(IWebDriver testDriver)
        {
            try
            {
                WaitHelper.WaitForElementPresent(testDriver, "ClassName", "ns-box-inner", 2);
                String Skill = skillSaved.Text;
                TestContext.Out.WriteLine(Skill);
                notificationText = notification.Text;
                Assert.AreEqual(notificationText, "JavaScript has been updated to your skills");
                test.Log(Status.Pass, "Skill has been updated successfully");
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
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Skill has not been updated"));
                }
            }
        }

        public void DeleteNewSkillBtn(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            // Click on the "Delete" button of skills
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//i[@class='remove icon']", 4);
            deleteSkill.Click();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void ValidateDeleteSkillDetails(IWebDriver testDriver)
        {
            try
            {
                this.testDriver = testDriver;
                WaitHelper.WaitForElementPresent(testDriver, "CssSelector", "tbody tr td:nth-child(1)", 2);
                String Skill = skillSaved.Text;
                notificationText = notification.Text;
                Assert.AreEqual(notification.Text, Skill + " " + "has been deleted");
                test.Log(Status.Pass, "Skill has been deleted successfully");
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
                    test.Log(Status.Fail, "Snapshot below: " + CommonMethods.SaveScreenShotClass.SaveScreenshot2(testDriver, "Skill has not been deleted"));
                }
            }
        }
    }
}
