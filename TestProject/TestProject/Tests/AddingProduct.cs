using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Pages;
using TestProject.Tests;

namespace TestProject;

public class AddingProduct : TestTemplate
{
    [Test]
    public void CheckAddingProductAction()
    {
        var loginPage = new LoginPage(driver);
        var inventoryPage = new InventoryPage(driver);
        loginPage.Login(
            this.jsonDataDeserialized.CorrectUsername,
            this.jsonDataDeserialized.CorrectPassword,
            this.wait);

        var currentCounterValue = inventoryPage.GetShoppingCartCounter();
        Assert.AreEqual(0, currentCounterValue, $"Shopping cart counter is visible. Current value: {currentCounterValue}");

        inventoryPage.GetProductList();
        var randomProduct = inventoryPage.GetOneRandomProduct();

        InventoryPage.AddProduct(randomProduct);
        currentCounterValue = inventoryPage.GetShoppingCartCounter();
        Assert.AreEqual(1, currentCounterValue, $"Shopping cart counter is not working properly. Current value: {currentCounterValue}");
    }
}
