using TestProject.Ui.Pages;

namespace TestProject.Ui.Tests;

public class MainPageLoading : TestTemplate
{
    [Test]
    public void CheckTitleAndLogoVisibility()
    {
        var loginPage = new LoginPage(driver);
        Assert.AreEqual(
            ExpectedTitle,
            driver.Title,
            "Title is not as expected.");

        Assert.IsTrue(
            loginPage.IsLoginContainerDisplayed(),
            "Login container is not visible.");
    }
}
