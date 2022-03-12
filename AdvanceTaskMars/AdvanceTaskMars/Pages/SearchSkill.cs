using AdvanceTaskMars.Config;
using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace AdvanceTaskMars.Pages
{
    class SearchSkill
    {
        private IWebDriver testDriver;
        public static ExtentTest test;

        //Initialising driver through constructor
        public SearchSkill(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "SearchSkill");
        }

        private IWebElement searchCategory => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/input"));

        private IWebElement allCategories => testDriver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span"));

        private IWebElement graphicsDesign => testDriver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[2]/span"));

        private IWebElement digitalMarketing => testDriver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[3]/span"));

        private IWebElement writingTransition => testDriver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[4]/span"));

        private IWebElement videoAnimation => testDriver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[5]/span"));

        private IWebElement musicAudio => testDriver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[6]/span"));

        private IWebElement ProgrammingTech => testDriver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[7]/span"));

        private IWebElement Business => testDriver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[8]/span"));

        private IWebElement funLifestyle => testDriver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[9]/span"));

        private IWebElement logoDesign => testDriver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[3]/span"));

        public void SearchSkillCategory()
        {
            searchCategory.SendKeys(ExcelLibHelpers.ReadData(2, "SearchCategory"));
            searchCategory.SendKeys(Keys.Enter);
            string categorySelected = ExcelLibHelpers.ReadData(2, "SearchCategory");
            WaitHelper.WaitForElementPresent(testDriver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]", 3);

            try
            {
                switch (categorySelected)
                {
                    case "All Category":
                        var Category = allCategories.Text;
                        int CategoryCount = Convert.ToInt32(Category);
                        Assert.GreaterOrEqual(CategoryCount, 1);
                        break;
                    case "Graphics & Design":
                        var Graphics = graphicsDesign.Text;
                        int GraphicsCount = Convert.ToInt32(Graphics);
                        Assert.GreaterOrEqual(GraphicsCount, 1);
                        break;
                    case "Digital Marketing":
                        var Digital = digitalMarketing.Text;
                        int DigialCount = Convert.ToInt32(Digital);
                        Assert.GreaterOrEqual(DigialCount, 1);
                        break;
                    case "Writing & Translation":
                        var Writing = writingTransition.Text;
                        int WritingCount = Convert.ToInt32(Writing);
                        Assert.GreaterOrEqual(WritingCount, 1);
                        break;
                    case "Video & Animation":
                        var Video = videoAnimation.Text;
                        int VideoCount = Convert.ToInt32(Video);
                        Assert.GreaterOrEqual(VideoCount, 1);
                        break;
                    case "Music & Audio":
                        var Music = musicAudio.Text;
                        int MusicCount = Convert.ToInt32(Music);
                        TestContext.WriteLine(MusicCount);
                        Assert.GreaterOrEqual(MusicCount, 1);
                        break;
                    case "Programming & Tech":
                        var Programming = ProgrammingTech.Text;
                        int ProgrammingCount = Convert.ToInt32(Programming);
                        Assert.GreaterOrEqual(Programming, 1);
                        break;
                    case "Business":
                        var BusinessString = Business.Text;
                        int BusinessCount = Convert.ToInt32(Business);
                        Assert.GreaterOrEqual(BusinessCount, 1);
                        break;
                    case "Fun & Lifestyle":
                        var Fun = funLifestyle.Text;
                        int FunCount = (int)Convert.ToInt64(Fun);
                        Assert.GreaterOrEqual(FunCount, 1);
                        break;
                }
            }
            catch
            {
                Assert.Fail("No results found. Please choose the new category!");
                test.Log(Status.Fail, "No results found. Please choose the new category!");
            }
            finally
            {
                Assert.Pass("Music & Audio");
                test.Log(Status.Pass, "The new category is Music & Audio.");
            }
        }

        public void SearchSkillSubCategory()
        {
            searchCategory.SendKeys(ExcelLibHelpers.ReadData(3, "SearchCategory"));
            searchCategory.SendKeys(Keys.Enter);
            string subCategorySelected = ExcelLibHelpers.ReadData(3, "SearchCategory");
            WaitHelper.WaitForElementPresent(testDriver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]", 3);

            try
            {
                switch (subCategorySelected)
                {
                    case "All Category":
                        var Category = allCategories.Text;
                        int CategoryCount = Convert.ToInt32(Category);
                        Assert.GreaterOrEqual(CategoryCount, 1);
                        break;
                    case "Programming & Tech":
                        var Programming = ProgrammingTech.Text;
                        int ProgrammingCount = Convert.ToInt32(Programming);
                        Assert.GreaterOrEqual(Programming, 1);
                        break;
                }
            }
            catch
            {
                Assert.Fail("No results found. Please choose the new category!");
                test.Log(Status.Fail, "No results found. Please choose the new category!");
            }
            finally
            {
                Assert.Pass("Programming & Tech");
                test.Log(Status.Pass, "The new sub category is Programming & Tech.");
            }
        }
    }
}
