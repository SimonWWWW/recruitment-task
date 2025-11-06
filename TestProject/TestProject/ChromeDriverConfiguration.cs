using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class ChromeDriverConfiguration
    {
        public static IWebDriver CreateDriver(bool isHeadless = false)
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
