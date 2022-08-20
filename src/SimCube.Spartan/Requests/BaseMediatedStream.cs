namespace SimCube.Spartan.Requests;

/// <summary>
/// Represents a base mediated stream.
/// </summary>
/// <typeparam name="TResult">The type of the result.</typeparam>
[ExcludeFromCodeCoverage]
public abstract class BaseMediatedStream<TResult> : IMediatedStream<TResult>
{
    /// <summary>
    /// Optionally Configures the Endpoint of the request.
    /// </summary>
    /// <returns>The route builder configuration action.</returns>
    public virtual Action<RouteHandlerBuilder>? ConfigureEndpoint() => null;
}
