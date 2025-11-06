using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject.Pages
{
    /// <summary>
    ///     Login page class.
    /// </summary>
    public class LoginPage
    {
        #region Constants

        /// <summary>
        ///     Login button id.
        /// </summary>
        private const string LoginButtonId = "login-button";

        /// <summary>
        ///     Username field id.
        /// </summary>
        private const string UsernameFieldId = "user-name";

        /// <summary>
        ///     Password field id.
        /// </summary>
        private const string PasswordFieldId = "password";

        /// <summary>
        ///     Error button class name.
        /// </summary>
        private const string ErrorButtonClassName = "error-button";

        /// <summary>
        ///     Login container XPath.
        /// </summary>
        private const string LoginContainerXPath = "//*[@id=\"root\"]/div";

        /// <summary>
        ///     Shopping cart logo id.
        /// </summary>
        public const string ShoppingCartLogoId = "shopping_cart_container";

        /// <summary>
        ///     Expected url after login.
        /// </summary>
        public const string ExpectedUrlAfterLogin = "https://www.saucedemo.com/inventory.html";

        /// <summary>
        ///     Error message container css selector.
        /// </summary>
        private const string ErrorMessageContainerCssSelector = ".error-message-container";

        #endregion

        #region Fields

        /// <summary>
        ///     IWebDriver field.
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        ///     WebDriverWait field.
        /// </summary>
        private readonly WebDriverWait wait;

        #endregion

        #region Constructors

        /// <summary>
        ///     Login page constructor.
        /// </summary>
        /// <param name="driver">
        ///     IWebDriver.
        /// </param>
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Login using username and password.
        /// </summary>
        /// <param name="username">
        ///     Username.
        /// </param>
        /// <param name="password">
        ///     Password.
        /// </param>
        /// <param name="wait">
        ///     WebDriverWait.
        /// </param>
        /// <param name="errorExpected">
        ///     True if is error expected, otherwise false;
        /// </param>
        public void Login(string username, string password, bool errorExpected = false)
        {
            if (errorExpected)
            {
                TestContext.WriteLine("Login using correct username from .json config.");
            }
            else
            {
                TestContext.WriteLine("Login using incorrect username/password from .json config.");
            }

            this.InsertUsername(username);
            this.InsertPassword(password);
            this.LoginButtonClick();

            if (!errorExpected)
            {
                this.wait.Until(ExpectedConditions.ElementIsVisible(By.Id(ShoppingCartLogoId)));
            }
        }

        /// <summary>
        ///     Check if login container is displayed.
        /// </summary>
        /// <returns>
        ///     True if is visible, otherwise false.
        /// </returns>
        public bool IsLoginContainerDisplayed()
        {
            try
            {
                this.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LoginContainerXPath)));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }


        /// <summary>
        ///     Inser username.
        /// </summary>
        /// <param name="username">
        ///     Username as string.
        /// </param>
        private void InsertUsername(string username)
        {
            this.SendKeysToField(UsernameFieldId, username);
        }

        /// <summary>
        ///     Insert password.
        /// </summary>
        /// <param name="password">
        ///     Password as string.
        /// </param>
        private void InsertPassword(string password)
        {
            this.SendKeysToField(PasswordFieldId, password);
        }

        /// <summary>
        ///     Login button click.
        /// </summary>
        private void LoginButtonClick()
        {
            try
            {
                this.driver.FindElement(By.Id(LoginButtonId)).Click();
            }
            catch(NotFoundException ex)
            {
                TestContext.WriteLine($"Exception: {ex.Message}");
            }
        }

        /// <summary>
        ///     Close error using button.
        /// </summary>
        public void CloseErrorButtonClick()
        {
            try
            {
                this.driver.FindElement(By.ClassName(ErrorButtonClassName)).Click();
            }
            catch (NotFoundException ex)
            {
                TestContext.WriteLine($"Exception: {ex.Message}");
            }
        }

        /// <summary>
        ///     Check if error is displayed.
        /// </summary>
        /// <returns>
        ///     True if is, otherwise false;
        /// </returns>
        public bool ErrorIsDisplayed()
        {
            try
            {
                var errorContainer = driver.FindElement(By.CssSelector(ErrorMessageContainerCssSelector));
                return errorContainer.Text != string.Empty;
            }
            catch (NotFoundException ex)
            {
                TestContext.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        ///     Send keys to field.
        /// </summary>
        /// <param name="fieldId">
        ///     Field id.
        /// </param>
        /// <param name="value">
        ///     Value to send.
        /// </param>
        private void SendKeysToField(string fieldId, string value)
        {
            try
            {
                this.driver.FindElement(By.Id(fieldId)).SendKeys(value);
            }
            catch(NotFoundException ex)
            {
                TestContext.WriteLine($"Exception: {ex.Message}");
            }
        }

        /// <summary>
        ///     Get field value.
        /// </summary>
        /// <param name="fieldId">
        ///     Field id.
        /// </param>
        /// <returns>
        ///     Field value.
        /// </returns>
        public string GetFieldValue(string fieldId)
        {
            try
            {
                return this.driver.FindElement(By.Id(fieldId)).Text;
            }
            catch (NotFoundException ex)
            {
                TestContext.WriteLine($"Exception: {ex.Message}");
                return string.Empty;
            }
        }

        #endregion
    }
}
