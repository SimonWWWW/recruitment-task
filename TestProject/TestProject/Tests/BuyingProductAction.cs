using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Pages;
using TestProject.Tests;

namespace TestProject;

public class BuyingProductAction : TestTemplate
{
    [Test]
    public void CheckBuyingProductAction()
    {
        var loginPage = new LoginPage(this.driver);
        var inventoryPage = new InventoryPage(this.driver);
        var checkoutPage = new CheckoutPage(this.driver);
        loginPage.Login(
            this.jsonDataDeserialized.CorrectUsername,
            this.jsonDataDeserialized.CorrectPassword);

        var currentCounterValue = inventoryPage.GetShoppingCartCounter();
        Assert.AreEqual(0, currentCounterValue, $"Shopping cart counter is visible. Current value: {currentCounterValue}");

        inventoryPage.AddOneRandomProduct();
        currentCounterValue = inventoryPage.GetShoppingCartCounter();
        Assert.AreEqual(1, currentCounterValue, $"Shopping cart counter is not working properly. Current value: {currentCounterValue}");
        inventoryPage.ClickOnShoppingCart();
        Assert.AreEqual(InventoryPage.ExpectedCartUrl, this.driver.Url, $"Wrong cart url: {this.driver.Url}");
        var itemList = inventoryPage.GetItemList();
        Assert.AreEqual(1, itemList.Count, $"Item list contains {itemList.Count} elements.");
        Assert.IsTrue(inventoryPage.CheckCartContent());

        inventoryPage.CheckoutButtonClick();

        Assert.AreEqual()

    }
}
