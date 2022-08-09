namespace SimCube.Spartan.Tests.Tests;

[UsesVerify]
public class PostExampleRequestTests : TestContext
{
    [Fact]
    public async Task PostExampleRequest_Valid_SuccessfulResponse()
    {
        var response = Client.PostAsync($"example/{TestData.UserName}/{TestData.ValidAge}", new StringContent(""));

        await Verify(response);
    }

    [Fact]
    public async Task PostExampleRequest_Invalid_SuccessfulResponse()
    {
        var response = Client.PostAsync($"example/{TestData.UserName}/{TestData.InvalidAge}", new StringContent(""));

        await Verify(response);
    }
}