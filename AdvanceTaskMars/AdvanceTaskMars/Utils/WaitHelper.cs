using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AdvanceTaskMars.Utils
{
    class WaitHelper
    {
        // To use generic reusable wait function for Element Present condition.
        public static void WaitForElementPresent(IWebDriver testDriver, string locationType, string locationValue, int seconds)
        {
            var wait = new WebDriverWait(testDriver, new TimeSpan(0, 0, seconds));

            if (locationType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locationValue)));
            }

            if (locationType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(locationValue)));
            }

            if (locationType == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(locationValue)));
            }

            if (locationType == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name(locationValue)));
            }

            if (locationType == "ClassName")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName(locationValue)));
            }
        }

        // To use generic reusable wait function for Element Visible condition.
        public static void WaitForElementVisible(IWebDriver testDriver, string locationType, string locationValue, int seconds)
        {
            var wait = new WebDriverWait(testDriver, new TimeSpan(0, 0, seconds));

            if (locationType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locationValue)));
            }

            if (locationType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locationValue)));
            }

            if (locationType == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locationValue)));
            }

            if (locationType == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(locationValue)));
            }

            if (locationType == "ClassName")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(locationValue)));
            }
        }

        // To use generic reusable wait function for Element Clickable condition 
        public static void WaitForElementToBeClickable(IWebDriver testDriver, string locationType, string locationValue, int seconds)
        {
            var wait = new WebDriverWait(testDriver, new TimeSpan(0, 0, seconds));

            if (locationType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locationValue)));
            }

            if (locationType == "Id")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locationValue)));
            }

            if (locationType == "CssSelector")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locationValue)));
            }

            if (locationType == "Name")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name(locationValue)));
            }

            if (locationType == "ClassName")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName(locationValue)));
            }
        }
    }
}
