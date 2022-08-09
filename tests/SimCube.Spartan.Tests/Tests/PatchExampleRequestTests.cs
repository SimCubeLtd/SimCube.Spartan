namespace SimCube.Spartan.Tests.Tests;

[UsesVerify]
public class PatchExampleRequestTests : TestContext
{
    [Fact]
    public async Task PatchExampleRequest_Valid_SuccessfulResponse()
    {
        var response = Client.PatchAsync($"example/{TestData.UserName}/{TestData.ValidAge}", new StringContent(""));

        await Verify(response);
    }

    [Fact]
    public async Task PatchExampleRequest_Invalid_SuccessfulResponse()
    {
        var response = Client.PatchAsync($"example/{TestData.UserName}/{TestData.InvalidAge}", new StringContent(""));

        await Verify(response);
    }
}