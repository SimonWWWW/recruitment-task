using System.Net;
using System.Text;
using System.Text.Json;

namespace TestProject.Api.Tests
{
    public class AddUser : ApiTestTemplate
    {
        [Test]
        public async Task AddUser_ShouldReturnCreatedResponse()
        {
            var newUser = CreateExpectedUser("Adam", "Adamowski",
                "adam.adamowski@example.com", "https://reqres.in/img/faces/1-image.jpg", null);

            var json = JsonSerializer.Serialize(newUser);
            var content = new StringContent(json, Encoding.UTF8, JsonMediaType);
            var response = await this.client.PostAsync(UsersUri, content);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(responseBody.Contains(json.Replace("}",string.Empty)));
        }

    }
}
