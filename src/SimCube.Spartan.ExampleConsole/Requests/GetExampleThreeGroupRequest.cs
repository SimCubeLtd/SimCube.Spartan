namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example get request.
/// </summary>
public class GetExampleThreeGroupRequest : IMediatedRequest<Results<Ok<string>, NotFound>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetExampleThreeGroupRequest"/> class.
    /// </summary>
    /// <param name="age">The age.</param>
    /// <param name="name">The name.</param>
    public GetExampleThreeGroupRequest(int age, string name)
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
