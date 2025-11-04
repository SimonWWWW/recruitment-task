using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace TestProject;

public class MainPageLoading
{
    #region Constants

    /// <summary>
    ///     Expected title.
    /// </summary>
    private const string ExpectedTitle = "Swag Labs";

    /// <summary>
    ///     Login container XPath.
    /// </summary>
    private const string LoginContainerXPath = "//*[@id=\"root\"]/div";

    #endregion

    #region Fields

    private IWebDriver driver;

    #endregion

    [OneTimeSetUp]
    public void Setup()
    {
        var jsonFilePath = Directory.EnumerateFiles(AppContext.BaseDirectory, "inputs.json").First();
        var jsonDataText = File.ReadAllText(jsonFilePath);
        var sauceDemoUrl = JsonConvert.DeserializeObject<JsonData>(jsonDataText).SauceDemoUrl;

        driver = ChromeDriverConfiguration.CreateDriver();
        driver.Navigate().GoToUrl(sauceDemoUrl);
    }

    [Test]
    public void CheckTitle()
    {
        Assert.AreEqual(ExpectedTitle, driver.Title, "Title is not as expected.");
    }

    [Test]
    public void CheckLogoAndLoginInputs()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        var loginContainer = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LoginContainerXPath)));
        Assert.That(loginContainer.Displayed, Is.True, "Login container is not visible.");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Dispose();
    }
}
