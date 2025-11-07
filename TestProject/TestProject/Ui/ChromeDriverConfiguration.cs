using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject.Ui
{
    /// <summary>
    ///     Chrome driver configuration class.
    /// </summary>
    public static class ChromeDriverConfiguration
    {
        /// <summary>
        ///     Create driver method.
        /// </summary>
        /// <param name="isHeadless">
        ///     If is headless option needed set true.
        /// </param>
        /// <returns>
        ///     IWebDriver.
        /// </returns>
        public static IWebDriver CreateDriver(bool isHeadless)
        {
            IWebDriver driver;
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            if (isHeadless)
            {
                chromeOptions.AddArgument("--headless=new");
            }

            // workaround for pop-up about password leak
            chromeOptions.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            driver = new ChromeDriver(chromeOptions);
            return driver;
        }
    }
}
