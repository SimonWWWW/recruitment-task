namespace TestProject.Ui
{
    /// <summary>
    ///     Json data class.
    /// </summary>
    public class JsonData
    {
        /// <summary>
        ///     SauceDemo URL.
        /// </summary>
        public string SauceDemoUrl { get; set; }

        /// <summary>
        ///     Correct username.
        /// </summary>
        public string CorrectUsername { get; set; }

        /// <summary>
        ///     Correct password.
        /// </summary>
        public string CorrectPassword { get; set; }

        /// <summary>
        ///     Incorrect username.
        /// </summary>
        public string IncorrectUsername { get; set; }

        /// <summary>
        ///     Incorrect password.
        /// </summary>
        public string IncorrectPassword { get; set; }

        /// <summary>
        ///     First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        ///     Headless mode.
        /// </summary>
        private string Headless { get; set; }

        /// <summary>
        ///     True if is headless mode.
        /// </summary>
        public bool IsHeadless => Boolean.TryParse(Headless, out var parsed);
    }
}
