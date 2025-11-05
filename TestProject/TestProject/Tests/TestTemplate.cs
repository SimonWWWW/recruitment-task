using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Tests
{
    public class TestTemplate
    {
        /// <summary>
        ///     Login container XPath.
        /// </summary>
        private const string LoginContainerXPath = "//*[@id=\"root\"]/div";

        /// <summary>
        ///     Expected title.
        /// </summary>
        public const string ExpectedTitle = "Swag Labs";

        public IWebDriver driver;
        public WebDriverWait wait;
        public JsonData jsonDataDeserialized;
        public string sauceDemoUrl;

        [SetUp]
        public void BaseSetup()
        {
            this.ReadAllJsonData();
            driver = ChromeDriverConfiguration.CreateDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.Navigate().GoToUrl(sauceDemoUrl);
            this.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LoginContainerXPath)));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Dispose();
        }

        private void ReadAllJsonData()
        {
            var jsonFilePath = Directory.EnumerateFiles(AppContext.BaseDirectory, "inputs.json").First();
            var jsonDataText = File.ReadAllText(jsonFilePath);
            this.jsonDataDeserialized = JsonConvert.DeserializeObject<JsonData>(jsonDataText);
            this.sauceDemoUrl = this.jsonDataDeserialized.SauceDemoUrl;

        }
    }
}
