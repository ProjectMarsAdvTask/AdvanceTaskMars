using AdvanceTaskMars.Config;
using AdvanceTaskMars.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdvanceTaskMars.Pages
{
    class LoginPage
    {
        private IWebDriver testDriver;

        //Initialising driver through constructor
        public LoginPage(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "Login");
        }

        private IWebElement logIn => testDriver.FindElement(By.XPath("//a[normalize-space()='Sign In']"));
        private IWebElement emailAddress => testDriver.FindElement(By.Name("email"));
        private IWebElement password => testDriver.FindElement(By.Name("password"));
        private IWebElement logInBtn => testDriver.FindElement(By.XPath("//button[normalize-space()='Login']"));
        private IWebElement profileName => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));

        //private IWebElement ProfileName2 => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/text()[2]"));

        private string Name = ExcelLibHelpers.ReadData(2, "name");

        public void LoginSteps(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "LogIn");
            //var Name = ExcelLibHelpers.ReadData(rownum, "name");
            WaitHelper.WaitForElementToBeClickable(testDriver, "XPath", "//a[normalize-space()='Sign In']", 2);
            logIn.Click();
            //testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            testDriver.SwitchTo().ActiveElement();
            emailAddress.Click();
            emailAddress.SendKeys(ExcelLibHelpers.ReadData(2, "username"));
            password.SendKeys(ExcelLibHelpers.ReadData(2, "password"));
            logInBtn.Click();
            TestContext.WriteLine(Name);

            Assert.AreEqual(profileName.Text, "Hi" + Name, "Actual username and expected username don't match");

            WaitHelper.WaitForElementPresent(testDriver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 2);
        }
    }
}
