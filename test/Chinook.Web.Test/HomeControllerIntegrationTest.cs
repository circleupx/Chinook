using Chinook.Web.Test.ApplicationFactory;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.Web.Test
{
    public class HomeControllerIntegrationTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _customWebApplicationFactory;

        public HomeControllerIntegrationTest(CustomWebApplicationFactory customWebApplicationFactory)
        {
            _customWebApplicationFactory = customWebApplicationFactory;
        }

        [Fact]
        public async Task GetHomeResource_HttpResponse_ShouldReturn200OK()
        {
            // Arrange
            using var httpClient = _customWebApplicationFactory.CreateClient();
            var requestUri = httpClient.BaseAddress.AbsoluteUri;

            // Act
            var sut = await httpClient.GetAsync(requestUri);

            // Assert 
            var responseCode = sut.StatusCode;
            responseCode.Should().BeEquivalentTo(HttpStatusCode.OK);
        } 
    }
}
