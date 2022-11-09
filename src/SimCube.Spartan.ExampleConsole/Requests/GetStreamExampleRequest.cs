namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example get stream request.
/// </summary>
[MediatedEndpoint(
    RequestType.MediatedGet,
    "getstream")]
[ExcludeFromCodeCoverage]
public record GetStreamExampleRequest : IMediatedStream<Person>;
