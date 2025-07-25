using Developer.Assignment.Api.Tests.Integration.Constants;
using Developer.Assignment.Api.Tests.Integration.Factories;
using FluentAssertions;
using System.Net;

namespace Developer.Assignment.Api.Tests.Integration;

[Collection(CollectionConstants.TestCollectionName)]
public class CreateProductEndpointTests(TestWebApplicationFactory webApplicationFactory)
{
    private readonly HttpClient _httpClient = webApplicationFactory.CreateClient();
    
    [Fact]
    public async Task GetProducts_ReturnsOk()
    {
        var response = await _httpClient.GetAsync("/api/products");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
