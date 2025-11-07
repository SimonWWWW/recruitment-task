using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject.Ui.Tests
{
    /// <summary>
    ///     Test template class.
    /// </summary>
    public class TestTemplate
    {
        #region Constants

        /// <summary>
        ///     Login container XPath.
        /// </summary>
        private const string LoginContainerXPath = "//*[@id=\"root\"]/div";

        #endregion

        #region Fields

        /// <summary>
        ///     Driver.
        /// </summary>
        public IWebDriver driver;

        /// <summary>
        ///     Json data deserialized.
        /// </summary>
        public JsonData jsonDataDeserialized;

        #endregion

        [SetUp]
        public void BaseSetup()
        {
            this.ReadAllJsonData();
            this.driver = ChromeDriverConfiguration.CreateDriver(this.jsonDataDeserialized.IsHeadless);
            this.driver.Navigate().GoToUrl(this.jsonDataDeserialized.SauceDemoUrl);
            new WebDriverWait(
                this.driver,
                TimeSpan.FromSeconds(5)).Until(
                ExpectedConditions.ElementIsVisible(By.XPath(LoginContainerXPath)));
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
            var jsonFilePath = Directory.EnumerateFiles(
                Path.Combine(TestContext.CurrentContext.TestDirectory, "..", "..", "..", "Ui"), "inputs.json").First();
            var jsonDataText = File.ReadAllText(jsonFilePath);
            this.jsonDataDeserialized = JsonConvert.DeserializeObject<JsonData>(jsonDataText);
        }
    }
}
