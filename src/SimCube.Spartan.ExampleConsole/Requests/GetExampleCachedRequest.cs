namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example get request.
/// </summary>
/// <param name="Age">The age.</param>
/// <param name="Name">The name.</param>
[CachePolicy(nameof(GetExampleCachedRequest))]
[MediatedEndpoint(RequestType.MediatedGet, "example-cached/{name}/{age}")]
public record GetExampleCachedRequest(int Age, string Name) : IMediatedRequest;
