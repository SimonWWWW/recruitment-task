using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject.Ui.Tests
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

        /// <summary>
        ///     Driver.
        /// </summary>
        public IWebDriver driver;

        /// <summary>
        ///     WebDriverWait.
        /// </summary>
        //public WebDriverWait wait;

        /// <summary>
        ///     Json data deserialized.
        /// </summary>
        public JsonData jsonDataDeserialized;

        [SetUp]
        public void BaseSetup()
        {
            this.ReadAllJsonData();
            this.driver = ChromeDriverConfiguration.CreateDriver();
            this.driver.Navigate().GoToUrl(jsonDataDeserialized.SauceDemoUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(ExpectedConditions.ElementIsVisible(By.XPath(LoginContainerXPath)));
        }

        [TearDown]
        public void Teardown()
        {
            this.driver.Dispose();
        }

        /// <summary>
        ///     Read all json file data.
        /// </summary>
        private void ReadAllJsonData()
        {
            var jsonFilePath = Directory.EnumerateFiles(Path.Combine(AppContext.BaseDirectory, "Ui"), "inputs.json").First();
            var jsonDataText = File.ReadAllText(jsonFilePath);
            this.jsonDataDeserialized = JsonConvert.DeserializeObject<JsonData>(jsonDataText);
        }
    }
}
