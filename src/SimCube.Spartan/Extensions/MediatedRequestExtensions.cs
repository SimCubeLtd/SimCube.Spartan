namespace SimCube.Spartan.Extensions;

/// <summary>
/// The extensions for Mediation request mapping.
/// </summary>
[ExcludeFromCodeCoverage]
public static class MediatedRequestExtensions
{
    /// <summary>
    /// Map Mediated Get requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedGet<TRequest>(this WebApplication app, string route, Action<RouteHandlerBuilder>? configureEndpoint = null, IReadOnlyCollection<IEndpointFilter>? endpointFilters = default)
    where TRequest : IMediatedRequest
    {
        var builder = app.MapGet(route, async (IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await mediator.Send(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }

    /// <summary>
    /// Map Mediated Post requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedPost<TRequest>(this WebApplication app, string route, Action<RouteHandlerBuilder>? configureEndpoint = null, IReadOnlyCollection<IEndpointFilter>? endpointFilters = default)
        where TRequest : IMediatedRequest
    {
        var builder = app.MapPost(route, async (IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) =>
            await mediator.Send(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }

    /// <summary>
    /// Map Mediated Put requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedPut<TRequest>(this WebApplication app, string route, Action<RouteHandlerBuilder>? configureEndpoint = null, IReadOnlyCollection<IEndpointFilter>? endpointFilters = default)
        where TRequest : IMediatedRequest
    {
        var builder = app.MapPut(route, async (IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) =>
            await mediator.Send(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }

    /// <summary>
    /// Map Mediated Patch requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedPatch<TRequest>(this WebApplication app, string route, Action<RouteHandlerBuilder>? configureEndpoint = null, IReadOnlyCollection<IEndpointFilter>? endpointFilters = default)
        where TRequest : IMediatedRequest
    {
        var builder = app.MapPatch(route, async (IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) =>
            await mediator.Send(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }

    /// <summary>
    /// Map Mediated Delete requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedDelete<TRequest>(this WebApplication app, string route, Action<RouteHandlerBuilder>? configureEndpoint = null, IReadOnlyCollection<IEndpointFilter>? endpointFilters = default)
        where TRequest : IMediatedRequest
    {
        var builder = app.MapDelete(route, async (IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) =>
            await mediator.Send(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }
}
