using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Pages
{
    /// <summary>
    ///     Inventory page class.
    /// </summary>
    public class InventoryPage
    {
        #region Constants

        private const string ProductClassName = "inventory_item";

        private const string ProductNameClassName = "inventory_item_name";

        private const string ShoppingCartProductCounterClassName = "shopping_cart_badge";

        private const string ShoppingCartLinkClassName = "shopping_cart_link";

        private const string CartItemClassName = "cart_item";

        private const string ButtonTagName = "button";

        private const string CheckoutButtonId = "checkout";

        public const string ExpectedCartUrl = "https://www.saucedemo.com/cart.html";

        #endregion

        #region Fields

        /// <summary>
        ///     IWebDriver field.
        /// </summary>
        private readonly IWebDriver driver;

        private List<IWebElement> productList;
        private string chosenProductName;
        private List<IWebElement> itemList;

        #endregion

        #region Constructors

        /// <summary>
        ///     Inventory page constructor.
        /// </summary>
        /// <param name="driver">
        ///     IWebDriver.
        /// </param>
        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Methods

        public void GetProductList()
        {
            this.productList = driver.FindElements(By.ClassName(ProductClassName)).ToList();

            TestContext.WriteLine($"Product list contains {this.productList.Count} elements.");
            if (this.productList.Count > 0)
            {
                TestContext.WriteLine($"Names:\n\r{string.Join("\n\r",
                    this.productList.Select(p => p.FindElement(By.ClassName(ProductNameClassName)).Text).ToList())}");
            }
        }

        public IWebElement GetOneRandomProduct()
        {
            Random random = new Random();
            var chosenProduct = this.productList.ElementAt(random.Next(0, this.productList.Count));
            this.chosenProductName = chosenProduct.FindElement(By.ClassName(ProductNameClassName)).Text;

            TestContext.WriteLine($"Chosen product: {chosenProductName}");

            return chosenProduct;
        }

        public int GetShoppingCartCounter()
        {
            try
            {
                return Int32.Parse(this.driver.FindElement(By.ClassName(ShoppingCartProductCounterClassName)).Text);
            }
            catch (NotFoundException) 
            {
                return 0;
            }
        }

        public static void AddProduct(IWebElement productToAdd)
        {
            try
            {
                var addToCartButton = productToAdd.FindElement(By.TagName(ButtonTagName));
                addToCartButton.Click();
            }
            catch (NotFoundException ex)
            {
                TestContext.WriteLine($"Exception message: {ex.Message}");
            }

        }

        public void AddOneRandomProduct()
        {
            this.GetProductList();
            AddProduct(this.GetOneRandomProduct());
        }

        public void ClickOnShoppingCart()
        {
            try
            {
                var shoppingCartElement = this.driver.FindElement(By.ClassName(ShoppingCartLinkClassName));
                shoppingCartElement.Click();
            }
            catch (NotFoundException ex)
            {
                TestContext.WriteLine($"Exception message: {ex.Message}");
            }
        }

        public void GetItemList()
        {
            this.itemList = this.driver.FindElements(By.ClassName(CartItemClassName)).ToList();
        }


        public bool CheckCartContent()
        {
            var productFromCart = this.itemList.First();

            var productFromCartName = productFromCart.FindElement(By.ClassName(ProductNameClassName)).Text;

            return productFromCartName.Equals(chosenProductName);
        }

        public void CheckoutButtonClick()
        {
            this.driver.FindElement(By.Id(CheckoutButtonId)).Click();
        }

        #endregion
    }
}
