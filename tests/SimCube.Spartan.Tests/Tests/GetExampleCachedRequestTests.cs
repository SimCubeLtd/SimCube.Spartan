using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace SimCube.Spartan.Tests.Tests;

[UsesVerify]
public class GetExampleCachedRequestTests : TestContext
{
    [Fact]
    public async Task GetExampleCachedRequest_Valid_SuccessfulResponse()
    {
        var response = Client.GetAsync($"example-cached/{TestData.UserName}/{TestData.ValidAge}");

        await Verify(response)
            .IgnoreMember("Headers");
    }

    [Fact]
    public async Task GetExampleCachedRequest_Invalid_SuccessfulResponse()
    {
        var response = Client.GetAsync($"example-cached/{TestData.UserName}/{TestData.InvalidAge}");

        await Verify(response)
            .IgnoreMember("Headers");
    }

    [Fact]
    public void GetExampleCachedRequest_HasName_GetRequest()
    {
        var endpointServices = Services.GetRequiredService<IEnumerable<EndpointDataSource>>();

        foreach (var endpointDataSource in endpointServices)
        {
            var endpoints = endpointDataSource.Endpoints;
            var endpoint = endpoints.FirstOrDefault(e => e.DisplayName == "HTTP: GET example-cached/{name}/{age}");
            endpoint.ShouldNotBeNull();
            endpoint.Metadata.GetMetadata<RouteNameMetadata>()?.RouteName.ShouldBe("GetExampleCached");
        }
    }
}