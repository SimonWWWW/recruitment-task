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
    public void CheckLoginAction()
    {
        var loginPage = new LoginPage(driver);
        loginPage.Login(
            this.jsonDataDeserialized.CorrectUsername,
            this.jsonDataDeserialized.CorrectPassword,
            this.wait);

        Assert.AreEqual(LoginPage.ExpectedUrlAfterLogin, driver.Url);
    }
}
