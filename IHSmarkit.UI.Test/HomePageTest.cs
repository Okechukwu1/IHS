using IHSmarkit.UI.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IHSmarkit.UI.Test
{
    [TestClass]
    public class HomePageTest
    {
        public static By OptionArrow = By.CssSelector("button.btn span.glyphicon.glyphicon-chevron-left");

        private static IWebDriver driver;
        private string url = "https://dotnetfiddle.net/";

        [TestMethod]
        [TestCategory("Chrome")]
        public void HideOptionsPanelTest()
        {

            Assert.IsTrue(driver.SafeWaitToBeVisible(OptionArrow, 5) != null, "The option arrow is not present");

            driver.FindElement(OptionArrow).Click();

            Assert.IsTrue(driver.WaitToBeInvisibleAndReturnBool(OptionArrow, 5), "The option arrow is present");

        }

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
