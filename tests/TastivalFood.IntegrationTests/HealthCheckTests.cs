using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TastivalFood.Api;
using Xunit;

namespace TastivalFood.IntegrationTests
{
    public sealed class HealthCheckTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public HealthCheckTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetHealthEndpoint_ShouldReturnSuccess()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/health");

            response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}
