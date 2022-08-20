namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example get stream request.
/// </summary>
[MediatedEndpoint(RequestType.MediatedGet, "getstream")]
[ExcludeFromCodeCoverage]
public class GetStreamExampleRequest : BaseMediatedStream<Person>
{
    /// <inheritdoc />
    public override Action<RouteHandlerBuilder> ConfigureEndpoint() =>
        builder => builder.AllowAnonymous();
}
