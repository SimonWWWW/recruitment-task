using TestProject.Pages;
using TestProject.Tests;
namespace TestProject;

public class MainPageLoading : TestTemplate
{
    [Test]
    public void CheckTitle()
    {
        Assert.AreEqual(
            ExpectedTitle,
            driver.Title,
            "Title is not as expected.");
    }

    [Test]
    public void CheckLogoAndLoginInputsVisibility()
    {
        Assert.IsTrue(
            LoginPage.IsLoginContainerDisplayed(this.wait),
            "Login container is not visible.");
    }
}
