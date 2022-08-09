namespace SimCube.Spartan.Tests.Tests;

[UsesVerify]
public class PutExampleRequestTests : TestContext
{
    [Fact]
    public async Task PutExampleRequest_Valid_SuccessfulResponse()
    {
        var response = Client.PutAsync($"example/{TestData.UserName}/{TestData.ValidAge}", new StringContent(""));

        await Verify(response);
    }

    [Fact]
    public async Task PutExampleRequest_Invalid_SuccessfulResponse()
    {
        var response = Client.PutAsync($"example/{TestData.UserName}/{TestData.InvalidAge}", new StringContent(""));

        await Verify(response);
    }
}