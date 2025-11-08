using System.Net;

namespace TestProject.Api.Tests
{
    public class GetUserNegative : ApiTestTemplate
    {
        [Test]
        public async Task GetUser_NonExistingId_ShouldReturnNull()
        {
            var response = await this.client.GetAsync(CreateUsersUriWithSpecifiedId(0));

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}