namespace SimCube.Spartan.Requests;

/// <summary>
/// Base request for all mediated requests.
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class BaseMediatedRequest : IMediatedRequest
{
    /// <summary>
    /// Gets the optional filters collection for endpoint middleware chaining via filters.
    /// </summary>
    public virtual List<IEndpointFilter> EndpointFilters => new();

    /// <summary>
    /// Optionally Configures the Endpoint of the request.
    /// </summary>
    /// <returns>The route builder configuration action.</returns>
    public virtual Action<RouteHandlerBuilder>? ConfigureEndpoint() => null;
}

/// <summary>
/// Base request for all mediated requests.
/// </summary>
/// <typeparam name="TResult">The type of the result.</typeparam>
[ExcludeFromCodeCoverage]
public abstract class BaseMediatedRequest<TResult> : IMediatedRequest<TResult>
{
    /// <summary>
    /// Gets the optional filters collection for endpoint middleware chaining via filters.
    /// </summary>
    public virtual List<IEndpointFilter> EndpointFilters => new();

    /// <summary>
    /// Optionally Configures the Endpoint of the request.
    /// </summary>
    /// <returns>The route builder configuration action.</returns>
    public virtual Action<RouteHandlerBuilder>? ConfigureEndpoint() => null;
}
