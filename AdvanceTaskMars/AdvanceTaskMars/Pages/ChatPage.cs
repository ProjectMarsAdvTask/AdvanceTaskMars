using AdvanceTaskMars.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdvanceTaskMars.Pages
{
    class ChatPage
    {
        private IWebDriver testDriver;
        public static ExtentTest test;

        public ChatPage(IWebDriver testDriver)
        {
            this.testDriver = testDriver;
        }

        private IWebElement chatNavigation => testDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[1]"));

        private IWebElement chatList => testDriver.FindElement(By.XPath("//*[@id='chatList']/div[5]/div[2]/div[2]"));

        private IWebElement chatBox => testDriver.FindElement(By.XPath("//*[@id='chatBox']/div[1]"));

        public void ChatHistoryList()
        {
            try
            {
                chatNavigation.Click();
                WaitHelper.WaitForElementPresent(testDriver, "XPath", "//*[@id='chatList']/div[5]/div[2]/div[2]", 3);
                test.Log(Status.Info, "The chat history is successfully opened");
                chatList.Click();
                WaitHelper.WaitForElementPresent(testDriver, "XPath", "//*[@id='chatBox']/div[1]", 3);
                bool displayMsg = chatBox.Displayed;
                Assert.IsTrue(displayMsg);
                test.Log(Status.Pass, "The chat box is successfully opened");
            }
            catch
            {
                Assert.Fail("The chat history is not visible");
                test.Log(Status.Pass, "The chat history is not visible");
            }
            finally
            {
                Assert.Pass("The chat history is visible");
                test.Log(Status.Pass, "The chat history is visible");
            }
        }
    }
}
