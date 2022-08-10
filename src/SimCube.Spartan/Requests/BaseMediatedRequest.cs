namespace SimCube.Spartan.Requests;

/// <summary>
/// Base request for all mediated requests.
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class BaseMediatedRequest : IMediatedRequest
{
    /// <summary>
    /// Optionally Configures the Endpoint of the request.
    /// </summary>
    /// <returns>The route builder configuration action.</returns>
    public virtual Action<RouteHandlerBuilder>? ConfigureEndpoint() => null;
}
