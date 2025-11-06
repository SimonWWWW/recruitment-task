using TestProject.Pages;
using TestProject.Tests;
namespace TestProject;

public class MainPageLoading : TestTemplate
{
    [Test]
    public void CheckTitleAndLogoVisibility()
    {
        Assert.AreEqual(
            ExpectedTitle,
            driver.Title,
            "Title is not as expected.");
        Assert.IsTrue(
            LoginPage.IsLoginContainerDisplayed(this.wait),
            "Login container is not visible.");
    }
}
