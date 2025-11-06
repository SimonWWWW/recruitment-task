using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Ui.Pages;

namespace TestProject.Ui.Tests;

public class BuyingProductAction : TestTemplate
{
    [Test]
    public void CheckBuyingProductAction()
    {
        var loginPage = new LoginPage(this.driver);
        var inventoryPage = new InventoryPage(this.driver);
        var checkoutPage = new CheckoutPage(this.driver);
        loginPage.Login(
            jsonDataDeserialized.CorrectUsername,
            jsonDataDeserialized.CorrectPassword);

        var currentCounterValue = inventoryPage.GetShoppingCartCounter();
        Assert.AreEqual(0, currentCounterValue, $"Shopping cart counter is visible. Current value: {currentCounterValue}");

        inventoryPage.AddOneRandomProduct();
        currentCounterValue = inventoryPage.GetShoppingCartCounter();
        Assert.AreEqual(1, currentCounterValue, $"Shopping cart counter is not working properly. Current value: {currentCounterValue}");
        inventoryPage.ClickOnShoppingCart();
        Assert.AreEqual(InventoryPage.ExpectedCartUrl, driver.Url, $"Wrong cart url: {driver.Url}");
        inventoryPage.GetItemList();
        Assert.AreEqual(1, inventoryPage.itemList.Count, $"Item list contains {inventoryPage.itemList.Count} elements.");
        Assert.IsTrue(inventoryPage.CheckCartContent());

        inventoryPage.CheckoutButtonClick();

        Assert.AreEqual(CheckoutPage.ExpectedUrlCheckoutFirstStep, driver.Url, $"Wrong checkout url: {driver.Url}");

        checkoutPage.FillInCustomerFields(jsonDataDeserialized.FirstName, jsonDataDeserialized.LastName, jsonDataDeserialized.PostalCode);


        checkoutPage.ContinueButtonClick();

        Assert.AreEqual(CheckoutPage.ExpectedUrlCheckoutSecondStep, driver.Url, $"Wrong checkout step two url: {driver.Url}");

        checkoutPage.FinishButtonClick();

        Assert.AreEqual(CheckoutPage.ExpectedUrlCheckoutCompleteStep, driver.Url, $"Wrong checkout step two url: {driver.Url}");

        Assert.IsTrue(checkoutPage.CheckIfCheckoutCompleteContainerIsVisible(), "Checkout complete container is not visible.");
    }
}
