using AdvanceTaskMars.Pages;
using AdvanceTaskMars.Pages.Profile;
using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace AdvanceTaskMars.NUnitTests.Profile
{
    [TestFixture]
    class ProfileSkillTest : CommonDriver
    {
        [Test, Order(1), Category("Skill")]
        public void AddProfileTest()
        {
            test = extent.CreateTest("Add Skill");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Home Page object initialization and definition
            HomePage homePgObj = new HomePage();
            homePgObj.SkillsPage(testDriver);

            // Profile Skill Page object initialization and definition
            ProfileSkill ProfileSkillObj = new ProfileSkill(testDriver);
            ProfileSkillObj.AddNewSkillsBtn(testDriver);
            ProfileSkillObj.AddSkills(testDriver);
            ProfileSkillObj.ValidateAddSkillDetails(testDriver);
            test.Log(Status.Info, "The skill has been added successfully");
            TestContext.WriteLine(ProfileSkillObj);
        }

        [Test, Order(2), Category("Skill")]
        public void EditProfileTest()
        {
            test = extent.CreateTest("Edit Skill");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Home Page object initialization and definition
            HomePage homePgObj = new HomePage();
            homePgObj.SkillsPage(testDriver);

            // Profile Skill Page object initialization and definition
            ProfileSkill ProfileSkillObj = new ProfileSkill(testDriver);
            ProfileSkillObj.EditSkillBtn(testDriver);
            ProfileSkillObj.EditSkill(testDriver);
            ProfileSkillObj.ValidateEditSkillDetails(testDriver);
            test.Log(Status.Info, "The skill has been updated successfully");
            TestContext.WriteLine(ProfileSkillObj);
        }

        [Test, Order(3), Category("Skill")]
        public void DeleteProfileTest()
        {
            test = extent.CreateTest("Delete Skill");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Home Page object initialization and definition
            HomePage homePgObj = new HomePage();
            homePgObj.SkillsPage(testDriver);

            // Profile Skill Page object initialization and definition
            ProfileSkill ProfileSkillObj = new ProfileSkill(testDriver);
            ProfileSkillObj.DeleteNewSkillBtn(testDriver);
            ProfileSkillObj.ValidateDeleteSkillDetails(testDriver);
            test.Log(Status.Info, "The skill has been deleted successfully");
            TestContext.WriteLine(ProfileSkillObj);
        }
    }
}
