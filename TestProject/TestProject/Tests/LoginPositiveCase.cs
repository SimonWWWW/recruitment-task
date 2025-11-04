using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Pages;

namespace TestProject;

public class LoginPositiveCase
{
    #region Fields

    /// <summary>
    ///     Login container XPath.
    /// </summary>
    private const string LoginContainerXPath = "//*[@id=\"root\"]/div";

    /// <summary>
    ///     Expected url after login.
    /// </summary>
    private const string ExpectedUrlAfterLogin = "https://www.saucedemo.com/inventory.html";

    /// <summary>
    ///     Shopping cart logo id.
    /// </summary>
    private const string ShoppingCartLogoId = "shopping_cart_container";

    private IWebDriver driver;

    private JsonData jsonDataDeserialized;

    private LoginPage loginPage;

    private WebDriverWait wait;

    #endregion

    [SetUp]
    public void Setup()
    {
        var jsonFilePath = Directory.EnumerateFiles(AppContext.BaseDirectory, "inputs.json").First();
        var jsonDataText = File.ReadAllText(jsonFilePath);
        this.jsonDataDeserialized = JsonConvert.DeserializeObject<JsonData>(jsonDataText);
        var sauceDemoUrl = this.jsonDataDeserialized.SauceDemoUrl;

        driver = ChromeDriverConfiguration.CreateDriver();
        this.loginPage = new LoginPage(driver);
        driver.Navigate().GoToUrl(sauceDemoUrl);
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        this.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LoginContainerXPath)));
    }

    [Test]
    public void CheckLoginAction()
    {
        var correctUsername = this.jsonDataDeserialized.CorrectUsername;
        var correctPassword = this.jsonDataDeserialized.CorrectPassword;

        TestContext.WriteLine("Using correct username from .json config.");
        loginPage.InsertUsername(correctUsername);

        TestContext.WriteLine("Using correct password from .json config.");
        loginPage.InsertPassword(correctPassword);
        loginPage.LoginButtonClick();
        this.wait.Until(ExpectedConditions.ElementIsVisible(By.Id(ShoppingCartLogoId)));
        Assert.AreEqual(ExpectedUrlAfterLogin, driver.Url);
    }


    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
    }
}
