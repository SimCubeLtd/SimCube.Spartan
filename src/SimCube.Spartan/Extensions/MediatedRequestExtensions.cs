using System.Runtime.CompilerServices;

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
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedGet<TRequest>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedRequest<IResult> =>
            MediatedGet<TRequest, IResult>(app, route, configureEndpoint, endpointFilters, namedCachePolicy, namedRateLimitPolicy);

    /// <summary>
    /// Map Mediated Get requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The optional result type.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedGet<TRequest, TResult>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
    where TRequest : IMediatedRequest<TResult>
    {
        var builder = app.MapGet(route, async ([FromServices] IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken)
            => await mediator.Send(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        if (namedRateLimitPolicy is not null)
        {
            builder.RequireRateLimiting(namedRateLimitPolicy);
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
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The optional result type.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedPost<TRequest, TResult>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedRequest<TResult>
    {
        var builder = app.MapPost(route, async ([FromServices] IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) =>
            await mediator.Send(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        if (namedRateLimitPolicy is not null)
        {
            builder.RequireRateLimiting(namedRateLimitPolicy);
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
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedPost<TRequest>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedRequest<IResult> =>
            MediatedPost<TRequest, IResult>(app, route, configureEndpoint, endpointFilters, namedCachePolicy, namedRateLimitPolicy);

    /// <summary>
    /// Map Mediated Put requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedPut<TRequest>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedRequest<IResult> =>
            MediatedPut<TRequest, IResult>(app, route, configureEndpoint, endpointFilters, namedCachePolicy, namedRateLimitPolicy);

    /// <summary>
    /// Map Mediated Put requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The optional result type.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedPut<TRequest, TResult>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedRequest<TResult>
    {
        var builder = app.MapPut(route, async ([FromServices] IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) =>
            await mediator.Send(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        if (namedRateLimitPolicy is not null)
        {
            builder.RequireRateLimiting(namedRateLimitPolicy);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }

    /// <summary>
    /// Map Mediated Get requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedPatch<TRequest>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedRequest<IResult> =>
            MediatedPatch<TRequest, IResult>(app, route, configureEndpoint, endpointFilters, namedCachePolicy, namedRateLimitPolicy);

    /// <summary>
    /// Map Mediated Patch requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The optional result type.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedPatch<TRequest, TResult>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedRequest<TResult>
    {
        var builder = app.MapPatch(route, async ([FromServices] IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) =>
            await mediator.Send(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        if (namedRateLimitPolicy is not null)
        {
            builder.RequireRateLimiting(namedRateLimitPolicy);
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
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The optional result type.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedDelete<TRequest, TResult>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedRequest<TResult>
    {
        var builder = app.MapDelete(route, async ([FromServices] IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) =>
            await mediator.Send(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        if (namedRateLimitPolicy is not null)
        {
            builder.RequireRateLimiting(namedRateLimitPolicy);
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
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedDelete<TRequest>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedRequest<IResult> =>
            MediatedDelete<TRequest, IResult>(app, route, configureEndpoint, endpointFilters, namedCachePolicy, namedRateLimitPolicy);

    /// <summary>
    /// Map Mediated Get streams to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <param name="configureEndpoint">The optional route handler configuration action for endpoint extension.</param>
    /// <param name="endpointFilters">The optional Endpoint filters to chain to the request pipeline.</param>
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedGetStream<TRequest, TResult>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
    where TRequest : IMediatedStream<TResult>
    {
        var builder = app.MapGet(route, ([FromServices] IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) => mediator.CreateStream(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        if (namedRateLimitPolicy is not null)
        {
            builder.RequireRateLimiting(namedRateLimitPolicy);
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
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedPostStream<TRequest, TResult>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedStream<TResult>
    {
        var builder = app.MapPost(route, ([FromServices] IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) => mediator.CreateStream(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        if (namedRateLimitPolicy is not null)
        {
            builder.RequireRateLimiting(namedRateLimitPolicy);
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
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedPutStream<TRequest, TResult>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedStream<TResult>
    {
        var builder = app.MapPut(route, ([FromServices] IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) => mediator.CreateStream(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        if (namedRateLimitPolicy is not null)
        {
            builder.RequireRateLimiting(namedRateLimitPolicy);
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
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedPatchStream<TRequest, TResult>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedStream<TResult>
    {
        var builder = app.MapPatch(route, ([FromServices] IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) => mediator.CreateStream(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        if (namedRateLimitPolicy is not null)
        {
            builder.RequireRateLimiting(namedRateLimitPolicy);
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
    /// <param name="namedCachePolicy">The optional named Output Cache Policy to use.</param>
    /// <param name="namedRateLimitPolicy">The optional named Rate Limit Policy to use.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static IEndpointRouteBuilder MediatedDeleteStream<TRequest, TResult>(
        this IEndpointRouteBuilder app,
        string route,
        Action<RouteHandlerBuilder>? configureEndpoint = null,
        IReadOnlyCollection<IEndpointFilter>? endpointFilters = default,
        string? namedCachePolicy = default,
        string? namedRateLimitPolicy = default)
        where TRequest : IMediatedStream<TResult>
    {
        var builder = app.MapDelete(route, ([FromServices] IMediator mediator, [AsParameters] TRequest request, CancellationToken cancellationToken) => mediator.CreateStream(request, cancellationToken));

        if (endpointFilters is { Count: > 0 })
        {
            builder.WithEndpointFilters(endpointFilters);
        }

        if (namedCachePolicy is not null)
        {
            builder.CacheOutput(namedCachePolicy);
        }

        if (namedRateLimitPolicy is not null)
        {
            builder.RequireRateLimiting(namedRateLimitPolicy);
        }

        configureEndpoint?.Invoke(builder);

        return app;
    }
}
