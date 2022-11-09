namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example get request.
/// </summary>
[MediatedEndpoint(RequestType.MediatedGet, "/example/{name}/{age}", true)]
public class GetExampleGroupRequest : BaseMediatedRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetExampleGroupRequest"/> class.
    /// </summary>
    /// <param name="age">The age.</param>
    /// <param name="name">The name.</param>
    public GetExampleGroupRequest(int age, string name)
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
}
