using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace IHSmarkit.UI.Test.Extensions
{
    public static class WebDriverExtensions
    {
        private static WebDriverWait wait;
        public static IWebElement SafeWaitToBeVisible(this IWebDriver driver, By locator, int timeInSecs)
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSecs));
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (ElementNotVisibleException)
            {
                return null;
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        public static bool WaitToBeInvisibleAndReturnBool(this IWebDriver driver, By locator, int waitSeconds)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
    }
}
