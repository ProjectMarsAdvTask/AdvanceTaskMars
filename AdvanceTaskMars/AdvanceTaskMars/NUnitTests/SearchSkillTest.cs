using AdvanceTaskMars.Pages;
using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace AdvanceTaskMars.NUnitTests
{
    [TestFixture]
    class SearchSkillTest : CommonDriver
    {
        [Test, Order(1), Category("Search Skill")]
        public void SearchSkillCategoryTest()
        {
            test = extent.CreateTest("Validate Search Skill using Category");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Search Skill object initialization and definition
            SearchSkill searchSkillObj = new SearchSkill(testDriver);
            searchSkillObj.SearchSkillCategory();

            TestContext.WriteLine(searchSkillObj);
        }

        [Test, Order(2), Category("Search Skill")]
        public void SearchSkillSubCategoryTest()
        {
            test = extent.CreateTest("Validate Search Skill using Sub Category");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Search Skill object initialization and definition
            SearchSkill searchSkillObj = new SearchSkill(testDriver);
            searchSkillObj.SearchSkillSubCategory();

            TestContext.WriteLine(searchSkillObj);
        }
    }
}
