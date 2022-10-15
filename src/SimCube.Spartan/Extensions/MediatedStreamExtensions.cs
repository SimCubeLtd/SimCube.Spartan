namespace SimCube.Spartan.Extensions;

/// <summary>
/// The extensions for Mediation request mapping.
/// </summary>
[ExcludeFromCodeCoverage]
public static class MediatedStreamExtensions
{
    /// <summary>
    /// Map Mediated Get streams to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <param name="namedCachePolicy">The named Output Cache Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedGetStream<TRequest, TResult>(
        this WebApplication app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default)
    where TRequest : IMediatedStream<TResult>
    {
        var builder = app.MapGet(route, (IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) => mediator.CreateStream(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }

    /// <summary>
    /// Map Mediated Post streams to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <param name="namedCachePolicy">The named Output Cache Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedPostStream<TRequest, TResult>(
        this WebApplication app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default)
        where TRequest : IMediatedStream<TResult>
    {
        var builder = app.MapPost(route, (IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) => mediator.CreateStream(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }

    /// <summary>
    /// Map Mediated Put streams to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <param name="namedCachePolicy">The named Output Cache Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedPutStream<TRequest, TResult>(
        this WebApplication app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default)
        where TRequest : IMediatedStream<TResult>
    {
        var builder = app.MapPut(route, (IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) => mediator.CreateStream(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }

    /// <summary>
    /// Map Mediated Patch streams to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <param name="namedCachePolicy">The named Output Cache Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedPatchStream<TRequest, TResult>(
        this WebApplication app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default)
        where TRequest : IMediatedStream<TResult>
    {
        var builder = app.MapPatch(route, (IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) => mediator.CreateStream(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }

    /// <summary>
    /// Map Mediated Delete streams to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <param name="namedCachePolicy">The named Output Cache Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedDeleteStream<TRequest, TResult>(
        this WebApplication app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default)
        where TRequest : IMediatedStream<TResult>
    {
        var builder = app.MapDelete(route, (IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) => mediator.CreateStream(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }
}
