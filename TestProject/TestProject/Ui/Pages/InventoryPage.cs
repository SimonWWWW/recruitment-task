using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject.Ui.Pages
{
    /// <summary>
    ///     Inventory page class.
    /// </summary>
    public class InventoryPage
    {
        #region Constants

        /// <summary>
        ///     Product class name.
        /// </summary>
        private const string ProductClassName = "inventory_item";

        /// <summary>
        ///     Product name class name.
        /// </summary>
        private const string ProductNameClassName = "inventory_item_name";

        /// <summary>
        ///     Shopping cart product counter class name.
        /// </summary>
        private const string ShoppingCartProductCounterClassName = "shopping_cart_badge";

        /// <summary>
        ///     Shopping cart link class name.
        /// </summary>
        private const string ShoppingCartLinkClassName = "shopping_cart_link";

        /// <summary>
        ///     Cart item class name.
        /// </summary>
        private const string CartItemClassName = "cart_item";

        /// <summary>
        ///     Button tag name.
        /// </summary>
        private const string ButtonTagName = "button";

        /// <summary>
        ///     Checkout button id.
        /// </summary>
        private const string CheckoutButtonId = "checkout";

        /// <summary>
        ///     Expected cart url.
        /// </summary>
        public const string ExpectedCartUrl = "cart.html";

        #endregion

        #region Fields

        /// <summary>
        ///     IWebDriver field.
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        ///     Product list.
        /// </summary>
        private List<IWebElement> productList;

        /// <summary>
        ///     Chosen product name.
        /// </summary>
        private string chosenProductName;

        /// <summary>
        ///     Item list.
        /// </summary>
        public List<IWebElement> itemList;

        /// <summary>
        ///     WebDriverWait field.
        /// </summary>
        private readonly WebDriverWait wait;

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
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Get product list method.
        /// </summary>
        public void GetProductList()
        {
            this.productList = this.driver.FindElements(By.ClassName(ProductClassName)).ToList();

            TestContext.WriteLine($"Product list contains {this.productList.Count} elements.");
            if (this.productList.Count > 0)
            {
                TestContext.WriteLine($"Names:\n\r{string.Join("\n\r",
                    this.productList.Select(p => p.FindElement(By.ClassName(ProductNameClassName)).Text).ToList())}");
            }
        }
        
        /// <summary>
        ///     Get one random product.
        /// </summary>
        /// <returns>
        ///     Chosen product.
        /// </returns>
        public IWebElement GetOneRandomProduct()
        {
            Random random = new Random();
            var chosenProduct = this.productList.ElementAt(random.Next(0, this.productList.Count));
            this.chosenProductName = chosenProduct.FindElement(By.ClassName(ProductNameClassName)).Text;

            TestContext.WriteLine($"Chosen product: {this.chosenProductName}");

            return chosenProduct;
        }

        /// <summary>
        ///     Get shopping cart counter.
        /// </summary>
        /// <returns>
        ///     Shopping cart counter - if is invisible - 0.
        /// </returns>
        public int GetShoppingCartCounter()
        {
            try
            {
                var shoppingCartCounterElement = this.wait.Until(
                    ExpectedConditions.ElementToBeClickable(By.ClassName(ShoppingCartProductCounterClassName)));
                return int.Parse(shoppingCartCounterElement.Text);
            }
            catch (WebDriverTimeoutException) 
            {
                return 0;
            }
        }

        /// <summary>
        ///     Add prodcut to cart.
        /// </summary>
        /// <param name="productToAdd">
        ///     Product to add.
        /// </param>
        public void AddProduct(IWebElement productToAdd)
        {
            try
            {
                this.wait.Until(
                    ExpectedConditions.ElementToBeClickable(productToAdd.FindElement(By.TagName(ButtonTagName)))).Click();
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Exception: {ex.Message}");
            }
        }

        /// <summary>
        ///     Add one random product method.
        /// </summary>
        public void AddOneRandomProduct()
        {
            this.GetProductList();
            this.AddProduct(this.GetOneRandomProduct());
        }

        /// <summary>
        ///     Click on shopping cart.
        /// </summary>
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

        /// <summary>
        ///     Get item list.
        /// </summary>
        public void GetItemList()
        {
            this.itemList = this.driver.FindElements(By.ClassName(CartItemClassName)).ToList();
        }

        /// <summary>
        ///     Check cart content.
        /// </summary>
        /// <returns>
        ///     True if chosen product exists in item list.
        /// </returns>
        public bool CheckCartContent()
        {
            var productFromCart = this.itemList.FirstOrDefault();
            if(productFromCart == null)
            {
                return false;
            }
            else
            {
                var productFromCartName = productFromCart.FindElement(By.ClassName(ProductNameClassName)).Text;
                return productFromCartName.Equals(chosenProductName);
            }
        }

        /// <summary>
        ///     Checkout button click.
        /// </summary>
        public void CheckoutButtonClick()
        {
            try
            {
                this.wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(CheckoutButtonId))).Click();
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Exception: {ex.Message}");
            }
        }

        #endregion
    }
}
