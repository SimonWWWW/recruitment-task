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

    private InventoryPage inventoryPage;

    #endregion

    [SetUp]
    public void Setup()
    {
        this.loginPage = new LoginPage(driver);
        this.inventoryPage = new InventoryPage(driver);
        this.loginPage.Login(
            this.jsonDataDeserialized.CorrectUsername,
            this.jsonDataDeserialized.CorrectPassword,
            this.wait);
    }


    [Test, Order(1)]
    public void CheckDefaultShoppingCartProductCounter()
    {
        var currentCounterValue = this.inventoryPage.GetShoppingCartCounter();
        Assert.AreEqual(0, currentCounterValue, $"Shopping cart counter is visible. Current value: {currentCounterValue}");
    }

    [Test, Order(2)]
    public void CheckAddingProductAction()
    {
        this.inventoryPage.GetProductList();
        var randomProduct = this.inventoryPage.GetOneRandomProduct();

        InventoryPage.AddProduct(randomProduct);
        var currentCounter = this.inventoryPage.GetShoppingCartCounter();
        Assert.AreEqual(1, currentCounter, $"Shopping cart counter is not working properly. Current value: {currentCounter}");
    }
}
