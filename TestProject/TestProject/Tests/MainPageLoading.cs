using TestProject.Pages;
using TestProject.Tests;
namespace TestProject;

public class MainPageLoading : TestTemplate
{
    [Test]
    public void CheckTitleAndLogoVisibility()
    {
        var loginPage = new LoginPage(this.driver);
        Assert.AreEqual(
            ExpectedTitle,
            this.driver.Title,
            "Title is not as expected.");

        Assert.IsTrue(
            loginPage.IsLoginContainerDisplayed(),
            "Login container is not visible.");
    }
}
