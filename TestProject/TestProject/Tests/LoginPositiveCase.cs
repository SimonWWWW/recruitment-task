using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Pages;
using TestProject.Tests;

namespace TestProject;

public class LoginPositiveCase : TestTemplate
{
    [Test]
    public void CheckLoginPositiveAction()
    {
        var loginPage = new LoginPage(driver);
        loginPage.Login(
            this.jsonDataDeserialized.CorrectUsername,
            this.jsonDataDeserialized.CorrectPassword);

        Assert.AreEqual(LoginPage.ExpectedUrlAfterLogin, driver.Url, $"Wrong cart url: {driver.Url}");
    }
}
