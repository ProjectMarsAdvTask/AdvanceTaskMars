using AdvanceTaskMars.Config;
using AdvanceTaskMars.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AdvanceTaskMars.Pages
{
    class ShareSkill
    {
        private IWebDriver testDriver;

        //Initialising driver through constructor
        public ShareSkill(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            PageFactory.InitElements(testDriver, this);
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "ShareSkill");
        }

        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement title { get; set; }

        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement description { get; set; }

        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement categoryId { get; set; }

        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement subCategoryId { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        private IWebElement tags { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        private IWebElement serviceTypeHourly { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        private IWebElement serviceTypeOneoff { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement locationTypeOnSite { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement locationTypeOnline { get; set; }

        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement startDate { get; set; }

        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement endDate { get; set; }

        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement sunday { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement monday { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[4]/div[1]/div/input")]
        private IWebElement tuesday { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[5]/div[1]/div/input")]
        private IWebElement wednesday { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[6]/div[1]/div/input")]
        private IWebElement thursday { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[7]/div[1]/div/input")]
        private IWebElement friday { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[8]/div[1]/div/input")]
        private IWebElement saturday { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input")]
        private IWebElement startTime1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input")]
        private IWebElement endtime1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement skillTradeExchange { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        private IWebElement skill_Exchange { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement skillTradeCredit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input")]
        private IWebElement credit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement active { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement hidden { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
        private IWebElement saveBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/span[1]/a")]
        private IWebElement deleteTag1 { get; set; }

        // Create Skill Share Page & add the title
        public void AddTitle(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            WaitHelper.WaitForElementPresent(testDriver, "Name", "title", 2);
            title.SendKeys(ExcelLibHelpers.ReadData(2, "Title"));
        }

        // Add the description
        public void AddDescription(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            WaitHelper.WaitForElementPresent(testDriver, "Name", "description", 2);
            description.SendKeys(ExcelLibHelpers.ReadData(2, "Description"));
        }

        // Select the category
        public void SelectAddCategory(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            WaitHelper.WaitForElementPresent(testDriver, "Name", "categoryId", 2);
            SelectElement select = new SelectElement(categoryId);
            var categoryData = ExcelLibHelpers.ReadData(2, "Category");
            select.SelectByText(categoryData);
        }

        //Select Sub Category
        public void SelectAddSubCategory(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            WaitHelper.WaitForElementPresent(testDriver, "Name", "subcategoryId", 2);
            SelectElement select = new SelectElement(subCategoryId);
            var subCategorydata = ExcelLibHelpers.ReadData(2, "SubCategory");
            select.SelectByText(subCategorydata);
        }

        // Add the Tags on Share skill
        public void AddEnterTags(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            var tagData = ExcelLibHelpers.ReadData(2, "Tag");
            tags.SendKeys(tagData);
            tags.SendKeys(Keys.Enter);
            var tagData1 = ExcelLibHelpers.ReadData(2, "Tag1");
            tags.SendKeys(tagData1);
            tags.SendKeys(Keys.Enter);
        }

        public void ServiceTypeHourly()
        {
            serviceTypeHourly.Click();
        }

        public void ServiceTypeOne_off()
        {
            serviceTypeOneoff.Click();
        }

        public void LocationTypeOnsite()
        {
            locationTypeOnSite.Click();
        }

        public void LocationTypeOnline()
        {
            locationTypeOnline.Click();
        }

        public void AddAvailableDays(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            var startDateData = ExcelLibHelpers.ReadData(2, "StartDate");
            startDate.SendKeys(startDateData);
            var endDateData = ExcelLibHelpers.ReadData(2, "EndDate");
            endDate.SendKeys(endDateData);
            monday.Click();
            var startTimeData = ExcelLibHelpers.ReadData(2, "StartTime");
            startTime1.SendKeys(startTimeData);
            var EndTimeData = ExcelLibHelpers.ReadData(2, "EndTime");
            endtime1.SendKeys(EndTimeData);
        }

        public void SkillExchange(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            skillTradeExchange.Click();
            var skill = ExcelLibHelpers.ReadData(2, "SkillExchange");
            skill_Exchange.SendKeys(skill);
            skill_Exchange.SendKeys(Keys.Enter);
            var skill1 = ExcelLibHelpers.ReadData(2, "SkillExchange1");
            skill_Exchange.SendKeys(skill1);
            skill_Exchange.SendKeys(Keys.Enter);
        }

        public void EditCreditExchange(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            skillTradeCredit.Click();
            var creditAmt = ExcelLibHelpers.ReadData(2, "Credit");
            credit.SendKeys(creditAmt);
        }

        public void ActiveShareSkill()
        {
            active.Click();
        }

        public void HiddenShareSkill()
        {
            hidden.Click();
        }

        public void SaveShareSkill()
        {
            saveBtn.Click();
        }

        // Edit Skill Share Page & the title
        public void EditTitle(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            title.Clear();
            WaitHelper.WaitForElementPresent(testDriver, "Name", "title", 3);
            title.SendKeys(ExcelLibHelpers.ReadData(3, "Title2"));
        }

        // Edit the description
        public void EditDescription(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            description.Clear();
            WaitHelper.WaitForElementPresent(testDriver, "Name", "description", 3);
            description.SendKeys(ExcelLibHelpers.ReadData(3, "Description2"));
        }

        // Edit the category
        public void SelectEditCategory(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            WaitHelper.WaitForElementPresent(testDriver, "Name", "categoryId", 2);
            SelectElement select = new SelectElement(categoryId);
            var categoryData = ExcelLibHelpers.ReadData(3, "Category2");
            select.SelectByText(categoryData);
        }

        //Edit Sub Category
        public void SelectEditSubCategory(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            WaitHelper.WaitForElementPresent(testDriver, "Name", "subcategoryId", 2);
            SelectElement select = new SelectElement(subCategoryId);
            var subCategorydata = ExcelLibHelpers.ReadData(3, "SubCategory");
            select.SelectByText(subCategorydata);
        }

        // Edit the Tags on Share skill
        public void EditTags(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            deleteTag1.Click();
            var tagData = ExcelLibHelpers.ReadData(3, "Tag");
            tags.SendKeys(tagData);
            tags.SendKeys(Keys.Enter);
            var tagData1 = ExcelLibHelpers.ReadData(3, "Tag1");
            tags.SendKeys(tagData1);
            tags.SendKeys(Keys.Enter);
        }

        public void EditAvailableDays(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            var startDateData = ExcelLibHelpers.ReadData(3, "StartDate");
            startDate.SendKeys(startDateData);
            var endDateData = ExcelLibHelpers.ReadData(3, "EndDate");
            endDate.SendKeys(endDateData);
        }
    }
}
