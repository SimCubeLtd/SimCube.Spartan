using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace SimCube.Spartan.Tests.Tests;

[UsesVerify]
public class GetExampleRequestTests : TestContext
{
    [Fact]
    public async Task GetExampleRequest_Valid_SuccessfulResponse()
    {
        var response = Client.GetAsync($"example/{TestData.UserName}/{TestData.ValidAge}");

        await Verify(response);
    }

    [Fact]
    public async Task GetExampleRequest_Invalid_SuccessfulResponse()
    {
        var response = Client.GetAsync($"example/{TestData.UserName}/{TestData.InvalidAge}");

        await Verify(response);
    }

    [Fact]
    public void GetExampleRequest_HasName_GetRequest()
    {
        var endpointServices = Services.GetRequiredService<IEnumerable<EndpointDataSource>>();

        foreach (var endpointDataSource in endpointServices)
        {
            var endpoints = endpointDataSource.Endpoints;
            var endpoint = endpoints.FirstOrDefault(e => e.DisplayName == "HTTP: GET example/{name}/{age}");
            endpoint.ShouldNotBeNull();
            endpoint.Metadata.GetMetadata<RouteNameMetadata>()?.RouteName.ShouldBe("GetExample");
        }
    }
}