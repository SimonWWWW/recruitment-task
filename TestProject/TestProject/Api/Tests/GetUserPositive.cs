using Allure.NUnit;
using Allure.NUnit.Attributes;
using System.Net;
using System.Text.Json;

namespace TestProject.Api.Tests
{
    /// <summary>
    ///     Get user positive case test.
    /// </summary>
    [AllureNUnit]
    [AllureSuite("Api")]
    public class GetUserPositive : ApiTestTemplate
    {
        [Test]
        public async Task GetUser_ExistingId_ShouldReturnUser()
        {
            var expectedResponseUser =
            CreateExpectedUser("George", "Bluth",
            "george.bluth@reqres.in", "https://reqres.in/img/faces/1-image.jpg", 1);

            var response = await this.client.GetAsync(CreateUsersUriWithSpecifiedId(1));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync();
            var responseBodyDeserialized = JsonSerializer.Deserialize<Root>(responseBody);
            CompareUser(expectedResponseUser, responseBodyDeserialized.Data, false);
        }
    }
}
