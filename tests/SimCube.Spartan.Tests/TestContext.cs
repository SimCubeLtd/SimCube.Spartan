namespace SimCube.Spartan.Tests;

public class TestContext : WebApplicationFactory<GetExampleRequest>
{
    public TestContext()
    {
        Client = CreateClient();
    }

    protected HttpClient Client { get;  }
}