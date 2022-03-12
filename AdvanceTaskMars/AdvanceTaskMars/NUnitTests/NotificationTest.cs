using AdvanceTaskMars.Pages;
using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace AdvanceTaskMars.NUnitTests
{
    [TestFixture]
    class NotificationTest : CommonDriver
    {
        [Test, Order(1), Description("Click on the Load More button & see more details info")]
        public void LoadMore()

        {
            test = extent.CreateTest("Validate the load more functionality");
            test.Log(Status.Info, "Browser Initialisation");
            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);

            loginPageObj.LoginSteps(testDriver);
            TestContext.WriteLine(loginPageObj);

            Notification notificationObj = new Notification(testDriver);
            notificationObj.NotifyDashBoardPage();
            notificationObj.ValidateLoadMore();
            Assert.Pass("All the data on Notification Page is loaded");
        }

        [Test, Order(2), Description("Click on the Show Less button & see lesser details info")]
        public void ShowLess()
        {
            test = extent.CreateTest("Validate the show less functionality");
            test.Log(Status.Info, "Browser Initialisation");
            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(testDriver);

            loginPageObj.LoginSteps(testDriver);
            TestContext.WriteLine(loginPageObj);
            test.Log(Status.Info, "The user had login successfully");

            Notification notificationObj = new Notification(testDriver);
            notificationObj.NotifyDashBoardPage();
            notificationObj.ValidateLoadMore();
            notificationObj.ValidateShowLess();
        }
    }
}
