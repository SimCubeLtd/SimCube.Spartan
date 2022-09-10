namespace SimCube.Spartan.Extensions;

/// <summary>
/// Extension methods for <see cref="IEndpointConventionBuilder"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public static class RouteHandlerBuilderExtensions
{
    /// <summary>
    /// Chain the endpoint filters onto the route handler.
    /// </summary>
    /// <param name="builder">The route handler instance.</param>
    /// <param name="filters">The filters to chain.</param>
    /// <returns>The endpoint with chained filters.</returns>
    public static IEndpointConventionBuilder WithEndpointFilters(this IEndpointConventionBuilder builder, IEnumerable<IEndpointFilter> filters)
    {
        foreach (var filter in filters)
        {
            builder.AddEndpointFilter(filter);
        }

        return builder;
    }
}
