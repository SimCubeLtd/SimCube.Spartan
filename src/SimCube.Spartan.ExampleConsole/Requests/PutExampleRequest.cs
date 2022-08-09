namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example put request.
/// </summary>
/// <param name="Age">The age.</param>
/// <param name="Name">The name.</param>
[MediatedRequest(RequestType.MediatedPut, "example/{name}/{age}")]
public record PutExampleRequest(int Age, string Name) : IMediatedRequest;
