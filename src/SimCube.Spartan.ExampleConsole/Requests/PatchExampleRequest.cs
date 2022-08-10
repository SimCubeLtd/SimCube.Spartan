namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example patch request.
/// </summary>
/// <param name="Age">The age.</param>
/// <param name="Name">The name.</param>
public record PatchExampleRequest(int Age, string Name) : IMediatedRequest;
