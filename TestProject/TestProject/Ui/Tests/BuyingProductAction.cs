using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using TestProject.Ui.Pages;

namespace TestProject.Ui.Tests;

/// <summary>
///     Buying product action class.
/// </summary>
[AllureNUnit]
public class BuyingProductAction : TestTemplate
{
    [Test]
    public void ShouldOrderBePossible_WhenUserFollowSteps()
    {
        var loginPage = new LoginPage(this.driver);
        var inventoryPage = new InventoryPage(this.driver);
        var checkoutPage = new CheckoutPage(this.driver);

        AllureApi.Step("Login with correct credentials.");
        loginPage.Login(
            this.jsonDataDeserialized.CorrectUsername,
            this.jsonDataDeserialized.CorrectPassword);

        AllureApi.Step("Check if shopping cart counter equals 0.");
        var currentCounterValue = inventoryPage.GetShoppingCartCounter();
        Assert.AreEqual(
            0,
            currentCounterValue,
            $"Shopping cart counter is visible. Current value: {currentCounterValue}");

        AllureApi.Step("Add one random product.");
        inventoryPage.AddOneRandomProduct();
        currentCounterValue = inventoryPage.GetShoppingCartCounter();

        AllureApi.Step("Check if shopping cart counter equals 1.");
        Assert.AreEqual(
            1,
            currentCounterValue,
            $"Shopping cart counter is not working properly. " +
            $"Current value: {currentCounterValue}");

        inventoryPage.ClickOnShoppingCart();
        AllureApi.Step("Check if click on shopping cart redirect to cart url.");
        Assert.IsTrue(
            this.driver.Url.EndsWith(InventoryPage.ExpectedCartUrl),
            $"Wrong cart url: {driver.Url}");

        inventoryPage.GetItemList();

        AllureApi.Step("Check if item list contains one element.");
        Assert.AreEqual(
            1,
            inventoryPage.itemList.Count,
            $"Item list contains {inventoryPage.itemList.Count} element(s).");

        AllureApi.Step("Check if cart contains selected product.");
        Assert.IsTrue(inventoryPage.CheckCartContent());

        inventoryPage.CheckoutButtonClick();
        AllureApi.Step("Check if click on checkout button redirect to checkout first step url.");
        Assert.IsTrue(
            this.driver.Url.EndsWith(CheckoutPage.ExpectedUrlCheckoutFirstStep),
            $"Wrong checkout url: {driver.Url}");

        AllureApi.Step("Fill customer fields - first name, last name, postal code.");
        checkoutPage.FillInCustomerFields(
            this.jsonDataDeserialized.FirstName,
            this.jsonDataDeserialized.LastName,
            this.jsonDataDeserialized.PostalCode);

        checkoutPage.ContinueButtonClick();
        AllureApi.Step("Check if click on continue button redirect to checkout second step url.");
        Assert.IsTrue(
            this.driver.Url.EndsWith(CheckoutPage.ExpectedUrlCheckoutSecondStep),
            $"Wrong checkout step two url: {driver.Url}");

        checkoutPage.FinishButtonClick();
        AllureApi.Step("Check if click on finish button redirect to checkout complete step url.");
        Assert.IsTrue(
            this.driver.Url.EndsWith(CheckoutPage.ExpectedUrlCheckoutCompleteStep),
            $"Wrong checkout step complete url: {driver.Url}");

        AllureApi.Step("Check if checkout complete container is visible.");
        Assert.IsTrue(
            checkoutPage.CheckIfCheckoutCompleteContainerIsVisible(),
            "Checkout complete container is not visible.");
    }
}
