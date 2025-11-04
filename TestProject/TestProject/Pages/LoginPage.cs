using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Pages
{
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

        #endregion

        #region Fields

        /// <summary>
        ///     IWebDriver field.
        /// </summary>
        private readonly IWebDriver driver;

        #endregion

        #region Constructors

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Inser username.
        /// </summary>
        /// <param name="username">
        ///     Username as string.
        /// </param>
        public void InsertUsername(string username)
        {
            this.SendKeysToField(UsernameFieldId, username);
        }

        /// <summary>
        ///     Insert password.
        /// </summary>
        /// <param name="password">
        ///     Password as string.
        /// </param>
        public void InsertPassword(string password)
        {
            this.SendKeysToField(PasswordFieldId, password);
        }

        /// <summary>
        ///     Login button click.
        /// </summary>
        public void LoginButtonClick()
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

        #endregion
    }
}
