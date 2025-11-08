using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Api.Tests
{
    /// <summary>
    ///     Api test template
    /// </summary>
    public class ApiTestTemplate
    {
        #region Contants

        /// <summary>
        ///     Reqres url.
        /// </summary>
        protected const string ReqresUrl = "https://reqres.in";

        /// <summary>
        ///     Users endpoint.
        /// </summary>
        protected const string UsersUri = "/api/users";

        /// <summary>
        ///     Header name for api key.
        /// </summary>
        protected const string HeaderName = "x-api-key";

        /// <summary>
        ///     Api key.
        /// </summary>
        protected const string ApiKey = "reqres-free-v1";

        #endregion

        #region Fields

        /// <summary>
        ///    Http client. 
        /// </summary>
        protected HttpClient client;

        /// <summary>
        ///     Create /api/users uri with specified id.
        /// </summary>
        /// <param name="id">
        ///     User id.
        /// </param>
        /// <returns>
        ///     Uri with user id.
        /// </returns>
        protected static string CreateUsersUriWithSpecifiedId(int id) => $"{UsersUri}/{id}";

        /// <summary>
        ///     Json media type header value.
        /// </summary>
        protected static MediaTypeHeaderValue JsonMediaType => new MediaTypeHeaderValue("application/json");

        #endregion

        [OneTimeSetUp]
        public void SetUp() 
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new System.Uri(ReqresUrl);
            this.client.DefaultRequestHeaders.Add(HeaderName, ApiKey);
        }

        [OneTimeTearDown]
        public void TearDown() 
        {
            this.client.Dispose();
        }

        /// <summary>
        ///     Create expected user in root.
        /// </summary>
        /// <param name="id">
        ///     User id.
        /// </param>
        /// <param name="firstName">
        ///     User first name.
        /// </param>
        /// <param name="lastName">
        ///     User last name.
        /// </param>
        /// <param name="email">
        ///     User email.
        /// </param>
        /// <param name="avatar">
        ///     User avatar.
        /// </param>
        /// <returns>
        ///     Expected user in root.
        /// </returns>
        protected static Data CreateExpectedUser(string firstName, string lastName, string email, string avatar, int? id = null)
        {
            return new Data()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Avatar = avatar
            };
        }

        /// <summary>
        ///     Compare response user with expected user.
        /// </summary>
        /// <param name="expectedUser">
        ///     Expected user data.
        /// </param>
        /// <param name="responseUser">
        ///     Response user data.
        /// </param>
        protected static void CompareUser(Data expectedUser, Data responseUser, bool checkId = true) 
        {
            if (checkId)
            {
                Assert.AreEqual(expectedUser.Id, responseUser.Id);
            }
            Assert.AreEqual(expectedUser.FirstName, responseUser.FirstName);
            Assert.AreEqual(expectedUser.LastName, responseUser.LastName);
            Assert.AreEqual(expectedUser.Email, responseUser.Email);
            Assert.AreEqual(expectedUser.Avatar, responseUser.Avatar);
        }
    }
}
