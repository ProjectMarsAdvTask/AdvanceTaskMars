using AdvanceTaskMars.Pages;
using AdvanceTaskMars.Pages.Profile;
using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace AdvanceTaskMars.NUnitTests.Profile
{
    [TestFixture]
    class ProfileDescriptionTest : CommonDriver
    {
        [Test, Order(1), Category("Description")]
        public void AddProfileTest()
        {
            test = extent.CreateTest("Add Description");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Profile Description Page object initialization and definition
            ProfileDescription ProfileDescObj = new ProfileDescription(testDriver);
            ProfileDescObj.DescriptionPenIcon(testDriver);
            ProfileDescObj.AddDescription(testDriver);
            ProfileDescObj.ValidateAddDescription1(testDriver);
            test.Log(Status.Info, "The description has been added successfully");
            TestContext.WriteLine(ProfileDescObj);
        }

        [Test, Order(2), Category("Description")]
        public void EditProfileTest()
        {
            test = extent.CreateTest("Edit Description");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Profile Description Page object initialization and definition
            ProfileDescription ProfileDescObj = new ProfileDescription(testDriver);
            ProfileDescObj.DescriptionPenIcon(testDriver);
            ProfileDescObj.EditDescription(testDriver);
            ProfileDescObj.ValidateAddDescription1(testDriver);
            test.Log(Status.Info, "The description has been edited successfully");
            TestContext.WriteLine(ProfileDescObj);
        }
    }
}
