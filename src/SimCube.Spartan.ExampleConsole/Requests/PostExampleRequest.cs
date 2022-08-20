namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example post request.
/// </summary>
/// <param name="Age">The age.</param>
/// <param name="Name">The name.</param>
[MediatedEndpoint(RequestType.MediatedPost, "example/{name}/{age}")]
public record PostExampleRequest(int Age, string Name) : IMediatedRequest;
