namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example delete request.
/// </summary>
[MediatedEndpoint(RequestType.MediatedDelete, "example/{name}/{age}")]
public class DeleteExampleRequest : BaseMediatedRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteExampleRequest"/> class.
    /// </summary>
    /// <param name="age">The age.</param>
    /// <param name="name">The name.</param>
    public DeleteExampleRequest(int age, string name)
    {
        Age = age;
        Name = name;
    }

    /// <summary>
    /// Gets the age.
    /// </summary>
    public int Age { get; }

    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; }

    /// <inheritdoc />
    public override Action<RouteHandlerBuilder> ConfigureEndpoint() => builder =>
        builder.AllowAnonymous()
            .WithName("DeleteStuff");
}
