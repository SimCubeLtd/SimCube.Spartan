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
    public async Task DeleteExampleRequest_Invalid_SuccessfulResponse()
    {
        var response = Client.DeleteAsync($"example/{TestData.UserName}/{TestData.InvalidAge}");

        await Verify(response);
    }
}