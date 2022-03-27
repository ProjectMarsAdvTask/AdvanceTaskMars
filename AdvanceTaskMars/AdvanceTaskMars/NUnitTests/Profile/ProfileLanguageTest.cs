using AdvanceTaskMars.Pages;
using AdvanceTaskMars.Pages.Profile;
using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace AdvanceTaskMars.NUnitTests.Profile
{
    [TestFixture]
    class ProfileLanguageTest : CommonDriver
    {
        [Test, Order(1), Category("Language")]
        public void AddProfileTest()
        {
            test = extent.CreateTest("Add Language");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Profile Language Page object initialization and definition
            ProfileLanguage ProfileLanguagecObj = new ProfileLanguage(testDriver);
            ProfileLanguagecObj.AddLanguageBtn(testDriver);
            ProfileLanguagecObj.AddLanguageDetails(testDriver);
            ProfileLanguagecObj.ValidateAddLanguageDetails(testDriver);
            test.Log(Status.Info, "The language has been added successfully");
            TestContext.WriteLine(ProfileLanguagecObj);
        }

        [Test, Order(2), Category("Language")]
        public void EditProfileTest()
        {
            test = extent.CreateTest("Edit Language");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Profile Language Page object initialization and definition
            ProfileLanguage ProfileLanguagecObj = new ProfileLanguage(testDriver);
            ProfileLanguagecObj.EditLanguageBtn(testDriver);
            ProfileLanguagecObj.EditLanguageDetails(testDriver);
            ProfileLanguagecObj.ValidateEditLanguageDetails(testDriver);
            test.Log(Status.Info, "The language has been edited successfully");
            TestContext.WriteLine(ProfileLanguagecObj);
        }

        [Test, Order(3), Category("Language")]
        public void DeleteProfileTest()
        {
            test = extent.CreateTest("Delete Language");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Profile Language Page object initialization and definition
            ProfileLanguage ProfileLanguagecObj = new ProfileLanguage(testDriver);
            ProfileLanguagecObj.DeleteLanguageDetails(testDriver);
            ProfileLanguagecObj.ValidateDeleteLanguageDetails(testDriver);
            test.Log(Status.Info, "The language has been deleted successfully");
            TestContext.WriteLine(ProfileLanguagecObj);
        }
    }
}
