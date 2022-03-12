using AdvanceTaskMars.Pages;
using AdvanceTaskMars.Pages.Profile;
using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace AdvanceTaskMars.NUnitTests.Profile
{
    [TestFixture]
    class ProfileCertificationTest : CommonDriver
    {
        [Test, Order(1), Category("Certification")]
        public void AddProfileTest()
        {
            test = extent.CreateTest("Add Certification");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Home Page object initialization and definition
            HomePage homePgObj = new HomePage();
            homePgObj.CertificationsPage(testDriver);

            // Profile Certifications Page object initialization and definition
            ProfileCertification ProfileCertificationObj = new ProfileCertification(testDriver);
            ProfileCertificationObj.AddCertificationBtn(testDriver);
            ProfileCertificationObj.AddCertification(testDriver);
            ProfileCertificationObj.ValidateAddCertDetails(testDriver);
            test.Log(Status.Info, "The certification has been added successfully");
            TestContext.WriteLine(ProfileCertificationObj);
        }

        [Test, Order(2), Category("Certification")]
        public void EditProfileTest()
        {
            test = extent.CreateTest("Edit Certification");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Home Page object initialization and definition
            HomePage homePgObj = new HomePage();
            homePgObj.CertificationsPage(testDriver);

            // Profile Certifications Page object initialization and definition
            ProfileCertification ProfileCertificationObj = new ProfileCertification(testDriver);
            ProfileCertificationObj.EditNewCertBtn(testDriver);
            ProfileCertificationObj.EditCertification(testDriver);
            ProfileCertificationObj.ValidateEditCertDetails(testDriver);
            test.Log(Status.Info, "The certification has been updated successfully");
            TestContext.WriteLine(ProfileCertificationObj);
        }

        [Test, Order(3), Category("Certification")]
        public void DeleteProfileTest()
        {
            test = extent.CreateTest("Delete Certification");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);
            loginPageObj.LoginSteps(testDriver);

            // Home Page object initialization and definition
            HomePage homePgObj = new HomePage();
            homePgObj.CertificationsPage(testDriver);

            // Profile Certifications Page object initialization and definition
            ProfileCertification ProfileCertificationObj = new ProfileCertification(testDriver);
            ProfileCertificationObj.DeleteNewCertBtn(testDriver);
            ProfileCertificationObj.ValidateDeleteCertDetails(testDriver);
            test.Log(Status.Info, "The certification has been deleted successfully");
            TestContext.WriteLine(ProfileCertificationObj);
        }
    }
}
