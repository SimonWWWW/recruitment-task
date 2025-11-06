using TestProject.Ui.Pages;

namespace TestProject.Ui.Tests;

/// <summary>
///     Login positive case class.
/// </summary>
public class LoginPositiveCase : TestTemplate
{
    [Test]
    public void ShouldLogin_WhenCorrectCredentialsAreUsed()
    {
        var loginPage = new LoginPage(driver);
        loginPage.Login(
            this.jsonDataDeserialized.CorrectUsername,
            this.jsonDataDeserialized.CorrectPassword);

        Assert.IsTrue(
            this.driver.Url.EndsWith(LoginPage.ExpectedUrlAfterLogin),
            $"Wrong login page url: {this.driver.Url}");
    }
}
