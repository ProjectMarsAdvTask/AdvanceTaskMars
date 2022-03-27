using AdvanceTaskMars.Pages;
using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;

namespace AdvanceTaskMars.NUnitTests
{
    [TestFixture]
    class ShareSkillTest : CommonDriver
    {
        [Test, Order(1), Description("Create the valid Share Skill record")]
        public void CreateShareSkillTest()
        {
            test = extent.CreateTest("Create Share Skill with Service Enabled");
            test.Log(Status.Info, "Browser Initialisation");
            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);

            loginPageObj.LoginSteps(testDriver);
            TestContext.WriteLine(loginPageObj);

            // Home Page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.ShareSkillBtn(testDriver);

            //SaveScreenShotClass.SaveScreenshot1(testDriver, "TestShareSkill");
            test.Log(Status.Info, "Share Skill Page is Opened");
            // Share Skill Page object initialization and definition
            ShareSkill shareSkillObj = new ShareSkill(testDriver);

            shareSkillObj.AddTitle(testDriver);
            shareSkillObj.AddDescription(testDriver);
            shareSkillObj.SelectAddCategory(testDriver);
            shareSkillObj.SelectAddSubCategory(testDriver);
            shareSkillObj.AddEnterTags(testDriver);
            shareSkillObj.ServiceTypeHourly();
            shareSkillObj.LocationTypeOnline();
            shareSkillObj.AddAvailableDays(testDriver);
            shareSkillObj.SkillExchange(testDriver);
            shareSkillObj.ActiveShareSkill();
            shareSkillObj.SaveShareSkill();
            test.Log(Status.Info, "ShareSkill is Saved");
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            // Manage Listings Page object initialization and definition
            ManageListings manageListsObj = new ManageListings(testDriver);
            manageListsObj.AddManageListingsActive(testDriver);
            test.Log(Status.Pass, "Assert Pass as condition is True & Manage listing is active");
        }

        [Test, Order(2), Description("Edit the valid Share Skill record")]
        public void EditShareSkillTest()
        {
            test = extent.CreateTest("Edit Share Skill with Skill Trade as Skill Exchange and change it to Credit");
            test.Log(Status.Info, "Browser Initialisation");
            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);

            loginPageObj.LoginSteps(testDriver);

            // Manage Listings Page object initialization and definition
            ManageListings manageListsObj = new ManageListings(testDriver);
            manageListsObj.NavigateManageListings();
            manageListsObj.EditManageListings();

            // Share Skill Page object initialization and definition
            ShareSkill shareSkillObj = new ShareSkill(testDriver);

            test.Log(Status.Info, "Share Skill Page is Opened");

            shareSkillObj.EditTitle(testDriver);
            shareSkillObj.EditDescription(testDriver);
            shareSkillObj.SelectEditCategory(testDriver);
            shareSkillObj.SelectEditSubCategory(testDriver);
            shareSkillObj.EditTags(testDriver);
            shareSkillObj.ServiceTypeOne_off();
            shareSkillObj.LocationTypeOnsite();
            shareSkillObj.EditAvailableDays(testDriver);
            shareSkillObj.EditCreditExchange(testDriver);
            shareSkillObj.HiddenShareSkill();
            shareSkillObj.SaveShareSkill();
            test.Log(Status.Info, "ShareSkill is Saved");

            manageListsObj.EditManageListingsHidden(testDriver);
            test.Log(Status.Pass, "Assert Pass as condition is True and Manage listing is Hidden");
        }
    }
}
