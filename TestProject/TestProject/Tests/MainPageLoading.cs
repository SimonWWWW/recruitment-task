using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Pages;
using TestProject.Tests;
namespace TestProject;

public class MainPageLoading : TestTemplate
{
    #region Constants


    #endregion

    [Test]
    public void CheckTitle()
    {
        Assert.AreEqual(
            ExpectedTitle,
            driver.Title,
            "Title is not as expected.");
    }

    [Test]
    public void CheckLogoAndLoginInputs()
    {
        Assert.IsTrue(
            LoginPage.IsLoginContainerDisplayed(this.wait),
            "Login container is not visible.");
    }
}
