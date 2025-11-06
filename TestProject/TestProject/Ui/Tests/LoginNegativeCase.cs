using TestProject.Ui.Pages;

namespace TestProject.Ui.Tests;

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
        this.loginPage.Login(
            this.jsonDataDeserialized.CorrectUsername,
            this.jsonDataDeserialized.IncorrectPassword,
            true);

        this.CheckErrorMessage();
    }

    [Test]
    public void ShouldErrorBeDisplayed_WhenUsernameIsIncorrect()
    {
        this.loginPage.Login(
            this.jsonDataDeserialized.IncorrectUsername,
            this.jsonDataDeserialized.CorrectPassword,
            true);

        this.CheckErrorMessage();
    }

    [Test]
    public void ShouldErrorBeDisplayed_WhenPasswordAndUsernameIsIncorrect()
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
        Assert.IsFalse(
            this.driver.Url.EndsWith(LoginPage.ExpectedUrlAfterLogin),
            $"Wrong url: {driver.Url}");
        Assert.IsTrue(this.loginPage.ErrorIsDisplayed());
        this.loginPage.CloseErrorButtonClick();
        Assert.IsFalse(this.loginPage.ErrorIsDisplayed());
    }
}
