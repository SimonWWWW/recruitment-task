using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using TestProject.Ui.Pages;

namespace TestProject.Ui.Tests;

/// <summary>
///     Main page loading class.
/// </summary>
[AllureNUnit]
[AllureSuite("Login")]
public class MainPageLoading : TestTemplate
{
    [Test]
    public void ShouldTitleAndLoginContainerBeVisible_WhenPageIsReady()
    {
        var loginPage = new LoginPage(driver);
        AllureApi.Step("Check if title is correct.");
        Assert.AreEqual(
            "Swag Labs",
            this.driver.Title,
            "Title is not as expected.");

        AllureApi.Step("Check if login container is visible.");
        Assert.IsTrue(
            loginPage.IsLoginContainerDisplayed(),
            "Login container is not visible.");
    }
}
