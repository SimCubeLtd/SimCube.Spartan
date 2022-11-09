namespace SimCube.Spartan.ExampleConsole.Requests;

/// <summary>
/// The example get request.
/// </summary>
[MediatedEndpoint(RequestType.MediatedGet, "/typed-results")]
public sealed class GetExampleWithTypeResultRequest : BaseMediatedRequest<Results<Ok<bool>, NotFound>>, IMediatedRequest<Results<Ok<bool>, NotFound>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetExampleWithTypeResultRequest"/> class.
    /// The example get request.
    /// </summary>
    /// <param name="name">The name.</param>
    public GetExampleWithTypeResultRequest(string name) => Name = name;

    /// <summary>Gets the name.</summary>
    public string Name { get; }

    /// <inheritdoc />
    public override Action<RouteHandlerBuilder>? ConfigureEndpoint() => builder =>
        builder.WithDescription("Pass 'Prom3theu5' for a 'true' result, anything else is not found.");
}
