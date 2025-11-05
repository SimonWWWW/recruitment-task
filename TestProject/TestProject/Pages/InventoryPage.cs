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

        private const string ButtonTagName = "button";

        #endregion

        #region Fields

        /// <summary>
        ///     IWebDriver field.
        /// </summary>
        private readonly IWebDriver driver;

        private List<IWebElement> productList;

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
            var chosenProductName = chosenProduct.FindElement(By.ClassName(ProductNameClassName));

            TestContext.WriteLine($"Chosen product: {chosenProductName}");

            return chosenProduct;
        }

        public int GetShoppingCartCounter()
        {
            try
            {
                return Int32.Parse(driver.FindElement(By.ClassName(ShoppingCartProductCounterClassName)).Text);
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

        #endregion
    }
}
