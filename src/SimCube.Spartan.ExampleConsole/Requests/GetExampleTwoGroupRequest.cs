namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example get request.
/// </summary>
public class GetExampleTwoGroupRequest : IMediatedRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetExampleTwoGroupRequest"/> class.
    /// </summary>
    /// <param name="age">The age.</param>
    /// <param name="name">The name.</param>
    public GetExampleTwoGroupRequest(int age, string name)
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
