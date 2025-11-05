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

        #endregion

        #region Fields

        /// <summary>
        ///     IWebDriver field.
        /// </summary>
        private readonly IWebDriver driver;

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
        public void Login(string username, string password, WebDriverWait wait, bool errorExpected = false)
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
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(ShoppingCartLogoId)));
            }
        }

        /// <summary>
        ///     Check if login container is displayed.
        /// </summary>
        /// <param name="wait">
        ///     Web driver wait.
        /// </param>
        /// <returns>
        ///     True if is visible, otherwise false.
        /// </returns>
        public static bool IsLoginContainerDisplayed(WebDriverWait wait)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(LoginContainerXPath)));
                return true;
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
                driver.FindElement(By.Id(LoginButtonId)).Click();
            }
            catch(Exception ex)
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
                driver.FindElement(By.ClassName(ErrorButtonClassName)).Click();
            }
            catch (Exception ex)
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
                var errorContainer = driver.FindElement(By.CssSelector(".error-message-container"));
                return errorContainer.Text != string.Empty;
            }
            catch (Exception ex)
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
                driver.FindElement(By.Id(fieldId)).SendKeys(value);
            }
            catch(Exception ex)
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
        protected string GetFieldValue(string fieldId)
        {
            try
            {
                return driver.FindElement(By.Id(fieldId)).Text;
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Exception: {ex.Message}");
                return string.Empty;
            }
        }

        #endregion
    }
}
