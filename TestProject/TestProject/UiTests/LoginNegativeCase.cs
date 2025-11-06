using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Pages;

namespace TestProject.UiTests;

public class LoginNegativeCase : TestTemplate
{
    #region Fields

    private LoginPage loginPage;

    #endregion

    [SetUp]
    public void Setup()
    {
        loginPage = new LoginPage(driver);
    }

    [Test]
    public void CheckLoginActionIncorrectPassword()
    {
        loginPage.Login(
            jsonDataDeserialized.CorrectUsername,
            jsonDataDeserialized.IncorrectPassword,
            true);

        CheckErrorMessage();
    }

    [Test]
    public void CheckLoginActionIncorrectUsername()
    {
        loginPage.Login(
            jsonDataDeserialized.IncorrectUsername,
            jsonDataDeserialized.CorrectPassword,
            true);

        CheckErrorMessage();
    }

    [Test]
    public void CheckLoginActionIncorrectUsernameAndPassword()
    {
        loginPage.Login(
            jsonDataDeserialized.IncorrectUsername,
            jsonDataDeserialized.IncorrectPassword,
            true);

        CheckErrorMessage();

    }

    /// <summary>
    ///     Check if error message is displayed.
    /// </summary>
    private void CheckErrorMessage()
    {
        Assert.AreNotEqual(LoginPage.ExpectedUrlAfterLogin, driver.Url, $"Wrong url: {driver.Url}");
        Assert.IsTrue(loginPage.ErrorIsDisplayed());
        loginPage.CloseErrorButtonClick();
        Assert.IsFalse(loginPage.ErrorIsDisplayed());
    }
}
