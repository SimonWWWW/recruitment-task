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
        #region Fields

        /// <summary>
        ///     IWebDriver field.
        /// </summary>
        private readonly IWebDriver driver;

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
    }
}
