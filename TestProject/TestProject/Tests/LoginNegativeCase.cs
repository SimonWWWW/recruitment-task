using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Pages;
using TestProject.Tests;

namespace TestProject;

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
    public void CheckLoginActionIncorrectPassword()
    {
        this.loginPage.Login(
            this.jsonDataDeserialized.CorrectUsername,
            this.jsonDataDeserialized.IncorrectPassword,
            true);

        this.CheckErrorMessage();
    }

    [Test]
    public void CheckLoginActionIncorrectUsername()
    {
        this.loginPage.Login(
            this.jsonDataDeserialized.IncorrectUsername,
            this.jsonDataDeserialized.CorrectPassword,
            true);

        this.CheckErrorMessage();
    }

    [Test]
    public void CheckLoginActionIncorrectUsernameAndPassword()
    {
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
        Assert.AreNotEqual(LoginPage.ExpectedUrlAfterLogin, driver.Url, $"Wrong cart url: {driver.Url}");
        Assert.IsTrue(loginPage.ErrorIsDisplayed());
        this.loginPage.CloseErrorButtonClick();
        Assert.IsFalse(loginPage.ErrorIsDisplayed());
    }
}
