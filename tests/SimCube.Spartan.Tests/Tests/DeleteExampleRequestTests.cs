using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace SimCube.Spartan.Tests.Tests;

[UsesVerify]
public class DeleteExampleRequestTests : TestContext
{
    [Fact]
    public async Task DeleteExampleRequest_Valid_SuccessfulResponse()
    {
        var response = Client.DeleteAsync($"example/{TestData.UserName}/{TestData.ValidAge}");

        await Verify(response);
    }

    [Fact]
    public async Task DeleteExampleRequestWithFilterOnName_Valid_SuccessfulResponse()
    {
        var response = Client.DeleteAsync($"example/{TestData.Prometheus}/{TestData.ValidAge}");

        await Verify(response);
    }

    [Fact]
    public async Task DeleteExampleRequestWithFilterOnName_InvalidAge_SuccessfulResponse()
    {
        var response = Client.DeleteAsync($"example/{TestData.Prometheus}/{TestData.InvalidAge}");

        await Verify(response);
    }

    [Fact]
    public async Task DeleteExampleRequest_Invalid_SuccessfulResponse()
    {
        var response = Client.DeleteAsync($"example/{TestData.UserName}/{TestData.InvalidAge}");

        await Verify(response);
    }

    [Fact]
    public void DeleteExampleRequest_HasName_DeleteStuff()
    {
        var endpointServices = Services.GetRequiredService<IEnumerable<EndpointDataSource>>();

        foreach (var endpointDataSource in endpointServices)
        {
            var endpoints = endpointDataSource.Endpoints;
            var endpoint = endpoints.FirstOrDefault(e => e.DisplayName == "HTTP: DELETE example/{name}/{age}");
            endpoint.ShouldNotBeNull();
            endpoint.Metadata.GetMetadata<RouteNameMetadata>()?.RouteName.ShouldBe("DeleteStuff");
        }
    }
}