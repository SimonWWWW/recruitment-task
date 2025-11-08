using System.Text.Json.Serialization;

namespace TestProject.Api
{
    /// <summary>
    ///     User json class.
    /// </summary>
    public class Data
    {
        /// <summary>
        ///     Id.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        ///     First name.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        /// <summary>
        ///     Last name.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        /// <summary>
        ///     Email.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        ///     Avatar url.
        /// </summary>
        [JsonPropertyName("avatar")]
        public string? Avatar { get; set; }
    }
}
