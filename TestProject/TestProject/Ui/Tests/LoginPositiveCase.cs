using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using NUnit.Allure.Core;
using TestProject.Ui.Pages;

namespace TestProject.Ui.Tests;

/// <summary>
///     Login positive case class.
/// </summary>
[AllureNUnit]
[AllureSuite("Login")]
public class LoginPositiveCase : TestTemplate
{
    [Test]
    public void ShouldLogin_WhenCorrectCredentialsAreUsed()
    {
        var loginPage = new LoginPage(driver);
        AllureApi.Step("Login with correct credentials.");
            loginPage.Login(
                this.jsonDataDeserialized.CorrectUsername,
                this.jsonDataDeserialized.CorrectPassword);
        AllureApi.Step("Verify redirection to expected url.");
            Assert.IsTrue(
            this.driver.Url.EndsWith(LoginPage.ExpectedUrlAfterLogin),
            $"Wrong login page url: {this.driver.Url}");
    }
}
