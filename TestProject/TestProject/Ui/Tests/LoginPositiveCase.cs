using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Ui.Pages;

namespace TestProject.Ui.Tests;

public class LoginPositiveCase : TestTemplate
{
    [Test]
    public void CheckLoginPositiveAction()
    {
        var loginPage = new LoginPage(driver);
        loginPage.Login(
            jsonDataDeserialized.CorrectUsername,
            jsonDataDeserialized.CorrectPassword);

        Assert.AreEqual(LoginPage.ExpectedUrlAfterLogin, driver.Url, $"Wrong login page url: {driver.Url}");
    }
}
