namespace SimCube.Spartan.ExampleConsole.Models;

/// <summary>
/// Represents a person.
/// </summary>
[ExcludeFromCodeCoverage]
public class Person
{
    /// <summary>
    /// Gets or sets the Name.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets the age.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Gets or sets the Email Address.
    /// </summary>
    public string EmailAddress { get; set; } = default!;
}
