using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Pages;

namespace TestProject;

public class LoginNegativeCase
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
    public void CheckLoginActionIncorrectPassword()
    {
        var correctUsername = this.jsonDataDeserialized.CorrectUsername;
        var incorrectPassword = this.jsonDataDeserialized.IncorrectPassword;

        TestContext.WriteLine("Using correct username from .json config.");
        loginPage.InsertUsername(correctUsername);

        TestContext.WriteLine("Using incorrect password from .json config.");
        loginPage.InsertPassword(incorrectPassword);
        loginPage.LoginButtonClick();
        this.wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(ShoppingCartLogoId)));
        Assert.AreNotEqual(ExpectedUrlAfterLogin, driver.Url);
    }

    [Test]
    public void CheckLoginActionIncorrectUsername()
    {
        var incorrectUsername = this.jsonDataDeserialized.IncorrectUsername;
        var correctPassword = this.jsonDataDeserialized.CorrectPassword;

        TestContext.WriteLine("Using incorrect username from .json config.");
        loginPage.InsertUsername(incorrectUsername);

        TestContext.WriteLine("Using correct password from .json config.");
        loginPage.InsertPassword(correctPassword);
        loginPage.LoginButtonClick();
        this.wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(ShoppingCartLogoId)));
        Assert.AreNotEqual(ExpectedUrlAfterLogin, driver.Url);
    }

    [Test]
    public void CheckLoginActionIncorrectUsernameAndPassword()
    {
        var incorrectUsername = this.jsonDataDeserialized.IncorrectUsername;
        var incorrectPassword = this.jsonDataDeserialized.IncorrectPassword;

        TestContext.WriteLine("Using incorrect username from .json config.");
        loginPage.InsertUsername(incorrectUsername);

        TestContext.WriteLine("Using incorrect password from .json config.");
        loginPage.InsertPassword(incorrectPassword);
        loginPage.LoginButtonClick();
        this.wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(ShoppingCartLogoId)));
        Assert.AreNotEqual(ExpectedUrlAfterLogin, driver.Url);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
    }
}
