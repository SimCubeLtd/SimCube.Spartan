namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example delete request.
/// </summary>
/// <param name="Age">The age.</param>
/// <param name="Name">The name.</param>
[MediatedRequest(RequestType.MediatedDelete, "example/{name}/{age}")]
public record DeleteExampleRequest(int Age, string Name) : IMediatedRequest;
