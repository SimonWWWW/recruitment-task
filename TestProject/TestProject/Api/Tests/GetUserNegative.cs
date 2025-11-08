using Allure.NUnit;
using Allure.NUnit.Attributes;
using System.Net;

namespace TestProject.Api.Tests
{
    /// <summary>
    ///     Get user negative case test.
    /// </summary>
    [AllureNUnit]
    [AllureSuite("GetUser")]
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