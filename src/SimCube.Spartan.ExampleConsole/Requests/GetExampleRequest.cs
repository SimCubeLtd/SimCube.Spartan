namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example get request.
/// </summary>
/// <param name="Age">The age.</param>
/// <param name="Name">The name.</param>
[MediatedRequest(RequestType.MediatedGet, "example/{name}/{age}")]
public record GetExampleRequest(int Age, string Name) : IMediatedRequest;
