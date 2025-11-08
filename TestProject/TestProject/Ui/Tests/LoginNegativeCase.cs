using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using TestProject.Ui.Pages;

namespace TestProject.Ui.Tests;

/// <summary>
///     Login negative case class.
/// </summary>
[AllureNUnit]
[AllureSuite("Login")]
public class LoginNegativeCase : TestTemplate
{
    #region Fields

    private LoginPage loginPage;

    #endregion

    [SetUp]
    public void Setup()
    {
        this.loginPage = new LoginPage(driver);
    }

    [Test]
    public void ShouldErrorBeDisplayed_WhenPasswordIsIncorrect()
    {
        AllureApi.Step("Login with incorrect password.");
        this.loginPage.Login(
            this.jsonDataDeserialized.CorrectUsername,
            this.jsonDataDeserialized.IncorrectPassword,
            true);

        this.CheckErrorMessage();
    }

    [Test]
    public void ShouldErrorBeDisplayed_WhenUsernameIsIncorrect()
    {
        AllureApi.Step("Login with incorrect username.");
        this.loginPage.Login(
            this.jsonDataDeserialized.IncorrectUsername,
            this.jsonDataDeserialized.CorrectPassword,
            true);

        this.CheckErrorMessage();
    }

    [Test]
    public void ShouldErrorBeDisplayed_WhenPasswordAndUsernameIsIncorrect()
    {
        AllureApi.Step("Login with incorrect username and password.");
        this.loginPage.Login(
            this.jsonDataDeserialized.IncorrectUsername,
            this.jsonDataDeserialized.IncorrectPassword,
            true);

        this.CheckErrorMessage();
    }

    /// <summary>
    ///     Check if error message is displayed.
    /// </summary>
    private void CheckErrorMessage()
    {
        AllureApi.Step("Check if login page is not loaded.");
        Assert.IsFalse(
            this.driver.Url.EndsWith(LoginPage.ExpectedUrlAfterLogin),
            $"Wrong url: {driver.Url}");

        AllureApi.Step("Check if error is displayed.");
        Assert.IsTrue(this.loginPage.ErrorIsDisplayed());

        AllureApi.Step("Check if close error button works correctly and error is not displayed after click.");
        this.loginPage.CloseErrorButtonClick();
        Assert.IsFalse(this.loginPage.ErrorIsDisplayed());
    }
}
