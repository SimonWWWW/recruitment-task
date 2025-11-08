using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using System.Net;
using System.Text;
using System.Text.Json;

namespace TestProject.Api.Tests
{
    /// <summary>
    ///     Add user test.
    /// </summary>
    [AllureNUnit]
    [AllureSuite("PostUser")]
    public class AddUser : ApiTestTemplate
    {
        [Test]
        public async Task AddUser_ShouldReturnCreatedResponse()
        {
            AllureApi.Step("Add new user - POST action");
            var newUser = CreateExpectedUser("Adam", "Adamowski",
                "adam.adamowski@example.com", "https://reqres.in/img/faces/1-image.jpg", null);
            var json = JsonSerializer.Serialize(newUser);
            var content = new StringContent(json, Encoding.UTF8, JsonMediaType);

            AllureApi.Step("Wait for response.");
            var response = await this.client.PostAsync(UsersUri, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            AllureApi.Step("Check if response status code equals 201 - created.");
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            AllureApi.Step("Check if response body contains new user data.");
            Assert.IsTrue(responseBody.Contains(json.Replace("}", string.Empty)));
        }

    }
}
