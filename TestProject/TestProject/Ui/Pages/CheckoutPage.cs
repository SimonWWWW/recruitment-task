using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject.Ui.Pages
{
    /// <summary>
    ///     Checkout page class.
    /// </summary>
    public class CheckoutPage
    {
        #region Constants

        /// <summary>
        ///     First name element id.
        /// </summary>
        private const string FirstNameId = "first-name";

        /// <summary>
        ///     Last name element id.
        /// </summary>
        private const string LastNameId = "last-name";

        /// <summary>
        ///     Postal code element id.
        /// </summary>
        private const string PostalCodeId = "postal-code";

        /// <summary>
        ///     Continue button id.
        /// </summary>
        private const string ContinueButtonId = "continue";

        /// <summary>
        ///     Finish button id.
        /// </summary>
        private const string FinishButtonId = "finish";

        /// <summary>
        ///     Checkout complete container id.
        /// </summary>
        public const string CheckoutCompleteContainerId = "checkout_complete_container";

        /// <summary>
        ///     Expected url checkout complete step.
        /// </summary>
        public const string ExpectedUrlCheckoutCompleteStep = "checkout-complete.html";

        /// <summary>
        ///     Expected url checkout first step.
        /// </summary>
        public const string ExpectedUrlCheckoutFirstStep = "checkout-step-one.html";

        /// <summary>
        ///     Expected url checkout second step.
        /// </summary>
        public const string ExpectedUrlCheckoutSecondStep = "checkout-step-two.html";

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

        #region Constructor 

        /// <summary>
        ///     Checkout page constructor.
        /// </summary>
        /// <param name="driver">
        ///     IWebDriver.
        /// </param>
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Insert first name.
        /// </summary>
        /// <param name="firstName">
        ///     First name as string.
        /// </param>
        private void InsertFirstName(string firstName)
        {
            this.SendKeysToField(FirstNameId, firstName);
        }

        /// <summary>
        ///     Insert last name.
        /// </summary>
        /// <param name="lastName">
        ///     Last name as string.
        /// </param>
        private void InsertLastName(string lastName)
        {
            this.SendKeysToField(LastNameId, lastName);
        }

        /// <summary>
        ///     Insert postal code.
        /// </summary>
        /// <param name="postalCode">
        ///     Postal code as string.
        /// </param>
        private void InsertPostalCode(string postalCode)
        {
            this.SendKeysToField(PostalCodeId, postalCode);
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
                this.wait.Until(
                    ExpectedConditions.ElementToBeClickable(this.driver.FindElement(By.Id(fieldId))))
                    .SendKeys(value);
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Exception: {ex.Message}");
            }
        }

        /// <summary>
        ///     Fill in customer fields.
        /// </summary>
        /// <param name="firstName">
        ///     First name.
        /// </param>
        /// <param name="lastName">
        ///     Last name.
        /// </param>
        /// <param name="postalCode">
        ///     Postal code.
        /// </param>
        public void FillInCustomerFields(string firstName, string lastName, string postalCode)
        {
            this.InsertFirstName(firstName);
            this.InsertLastName(lastName);
            this.InsertPostalCode(postalCode);
        }

        /// <summary>
        ///     Continue button click.
        /// </summary>
        public void ContinueButtonClick()
        {
            try
            {
                this.wait.Until(
                    ExpectedConditions.ElementToBeClickable(By.Id(ContinueButtonId))).Click();
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Exception: {ex.Message}");
            }
        }

        /// <summary>
        ///     Finish button click.
        /// </summary>
        public void FinishButtonClick()
        {
            try
            {
                this.wait.Until(
                    ExpectedConditions.ElementToBeClickable(By.Id(FinishButtonId))).Click();
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail($"Exception: {ex.Message}");
            }
        }

        /// <summary>
        ///     Check if checkout complete container is visible.
        /// </summary>
        /// <returns></returns>
        public bool CheckIfCheckoutCompleteContainerIsVisible()
        {
            try
            {
                this.wait.Until(ExpectedConditions.ElementIsVisible(By.Id(CheckoutCompleteContainerId)));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        #endregion

    }
}
