using TestProject.Ui.Pages;

namespace TestProject.Ui.Tests;

/// <summary>
///     Buying product action class.
/// </summary>
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
        Assert.AreEqual(
            0,
            currentCounterValue,
            $"Shopping cart counter is visible. Current value: {currentCounterValue}");

        inventoryPage.AddOneRandomProduct();
        currentCounterValue = inventoryPage.GetShoppingCartCounter();
        Assert.AreEqual(
            1,
            currentCounterValue,
            $"Shopping cart counter is not working properly. " +
            $"Current value: {currentCounterValue}");

        inventoryPage.ClickOnShoppingCart();
        Assert.IsTrue(
            this.driver.Url.EndsWith(InventoryPage.ExpectedCartUrl),
            $"Wrong cart url: {driver.Url}");
        inventoryPage.GetItemList();
        Assert.AreEqual(
            1,
            inventoryPage.itemList.Count,
            $"Item list contains {inventoryPage.itemList.Count} elements.");
        Assert.IsTrue(inventoryPage.CheckCartContent());

        inventoryPage.CheckoutButtonClick();
        Assert.IsTrue(
            this.driver.Url.EndsWith(CheckoutPage.ExpectedUrlCheckoutFirstStep),
            $"Wrong checkout url: {driver.Url}");

        checkoutPage.FillInCustomerFields(
            this.jsonDataDeserialized.FirstName,
            this.jsonDataDeserialized.LastName,
            this.jsonDataDeserialized.PostalCode);


        checkoutPage.ContinueButtonClick();
        Assert.IsTrue(
            this.driver.Url.EndsWith(CheckoutPage.ExpectedUrlCheckoutSecondStep),
            $"Wrong checkout step two url: {driver.Url}");

        checkoutPage.FinishButtonClick();
        Assert.IsTrue(
            this.driver.Url.EndsWith(CheckoutPage.ExpectedUrlCheckoutCompleteStep),
            $"Wrong checkout step two url: {driver.Url}");

        Assert.IsTrue(
            checkoutPage.CheckIfCheckoutCompleteContainerIsVisible(),
            "Checkout complete container is not visible.");
    }
}
