using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AdvanceTaskMars.Pages
{
    class HomePage
    {
        private IWebDriver testDriver;

        private IWebElement MouseHover => testDriver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]/div/span"));

        private IWebElement GoToProfile => testDriver.FindElement(By.XPath("//*[@id='service-search-section']/div[1]/div[2]/div/span/div/a[1]"));

        private IWebElement skillsTab => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));

        private IWebElement educationTab => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));

        private IWebElement certificationsTab => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));

        private IWebElement ShareSkills => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a"));

        private IWebElement ManageListing => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]"));

        private IWebElement MarsLogo => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/a"));

        private IWebElement searchBtn => testDriver.FindElement(By.XPath("//*[@id='home']/div/div/div[3]/div/button"));

        public void NaviHomePage(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            Actions Hover = new Actions(testDriver);
            // Select the Seller from "Seller" dropdown list
            Hover.MoveToElement(MouseHover).Perform();
            // Select the "Go to Profile" from "Seller" dropdown list
            GoToProfile.Click();
        }

        public void SkillsPage(IWebDriver testDriver)
        {
            // Navigate to the Skills Tab
            this.testDriver = testDriver;
            //WaitHelpers.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 2);
            skillsTab.Click();
        }

        public void EducationPage(IWebDriver testDriver)
        {
            // Navigate to the Education Tab
            this.testDriver = testDriver;
            //WaitHelpers.WaitForElementToBeClickable(testDriver, "XPath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 2);
            educationTab.Click();
        }

        public void CertificationsPage(IWebDriver testDriver)
        {
            // Navigate to the Certifications Tab
            this.testDriver = testDriver;
            //WaitHelpers.WaitForElementToBeClickable(testDriver, "XPath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 2);
            certificationsTab.Click();
        }

        public void ShareSkillBtn(IWebDriver testDriver)
        {
            // Navigate to the Share Skill Button
            this.testDriver = testDriver;
            ShareSkills.Click();
        }

        public void NaviManageListings(IWebDriver testDriver)
        {
            // Navigate to the Manage Listings Tab
            this.testDriver = testDriver;
            ManageListing.Click();
        }

        public void NavigateMarsLogo(IWebDriver testDriver)
        {
            // Navigate to the Mars Logo and the search button in the home page
            this.testDriver = testDriver;
            MarsLogo.Click();
            searchBtn.Click();
        }
    }
}
