using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Pages;
using TestProject.Tests;

namespace TestProject;

public class AddingProduct : TestTemplate
{
    #region Fields

    private LoginPage loginPage;

    #endregion

    [SetUp]
    public void Setup()
    {
        this.loginPage = new LoginPage(driver);
    }

    [Test]
    public void CheckAddingProductAction()
    {
        this.loginPage.Login(
            this.jsonDataDeserialized.CorrectUsername,
            this.jsonDataDeserialized.CorrectPassword,
            this.wait);

        Assert.AreEqual(LoginPage.ExpectedUrlAfterLogin, driver.Url);

        Assert.IsTrue(driver.FindElements(By.ClassName("shopping_cart_badge")).Count == 0, "Shopping cart counter is visible.");

        var productsList = driver.FindElements(By.ClassName("inventory_item"));

        TestContext.WriteLine($"Products list contains {productsList.Count} elements.\n\r" +
            $"Names:\n\r{string.Join("\n\r", 
            productsList.Select(p => p.FindElement(By.ClassName("inventory_item_name")).Text).ToList())}");

        Random random = new Random();
        var chosenProduct = productsList.ElementAt(random.Next(0, productsList.Count));
        var chosenProductName = chosenProduct.FindElement(By.ClassName("inventory_item_name"));

        TestContext.WriteLine($"Chosen product: {chosenProductName}");

        var addToCartButton = chosenProduct.FindElement(By.TagName("button"));
        addToCartButton.Click();

        var shoppingCartElement = driver.FindElement(By.Id(LoginPage.ShoppingCartLogoId));
        var shoppingCartCounter = driver.FindElements(By.ClassName("shopping_cart_badge")).FirstOrDefault();
        Assert.IsTrue(shoppingCartCounter.Displayed, "Shopping cart counter is not visible.");

        Assert.AreEqual("1", shoppingCartCounter.Text);
    }
}
