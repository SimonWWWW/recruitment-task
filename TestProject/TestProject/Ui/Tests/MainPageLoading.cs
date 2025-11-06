using TestProject.Ui.Pages;

namespace TestProject.Ui.Tests;

/// <summary>
///     Main page loading class.
/// </summary>
public class MainPageLoading : TestTemplate
{
    [Test]
    public void ShouldTitleAndLoginContainerBeVisible_WhenPageIsReady()
    {
        var loginPage = new LoginPage(driver);
        Assert.AreEqual(
            "Swag Labs",
            this.driver.Title,
            "Title is not as expected.");

        Assert.IsTrue(
            loginPage.IsLoginContainerDisplayed(),
            "Login container is not visible.");
    }
}
