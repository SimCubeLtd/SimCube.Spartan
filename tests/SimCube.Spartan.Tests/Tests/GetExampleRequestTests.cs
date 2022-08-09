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
}