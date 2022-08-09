namespace SimCube.Spartan.Extensions;

/// <summary>
/// The extensions for Mediation request mapping.
/// </summary>
public static class MediatedExtensions
{
    /// <summary>
    /// Map Mediated Get requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedGet<TRequest>(this WebApplication app, string route)
    where TRequest : IMediatedRequest
    {
        app.MapGet(route, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));

        return app;
    }

    /// <summary>
    /// Map Mediated Post requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedPost<TRequest>(this WebApplication app, string route)
        where TRequest : IMediatedRequest
    {
        app.MapPost(route, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));

        return app;
    }

    /// <summary>
    /// Map Mediated Put requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedPut<TRequest>(this WebApplication app, string route)
        where TRequest : IMediatedRequest
    {
        app.MapPut(route, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));

        return app;
    }

    /// <summary>
    /// Map Mediated Patch requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedPatch<TRequest>(this WebApplication app, string route)
        where TRequest : IMediatedRequest
    {
        app.MapPatch(route, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));

        return app;
    }

    /// <summary>
    /// Map Mediated Delete requests to the specified controller action.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="route">the route to map the request on.</param>
    /// <typeparam name="TRequest">The type of the request to map with its parameters.</typeparam>
    /// <returns>A type of <see cref="IResult"/>.</returns>
    public static WebApplication MediatedDelete<TRequest>(this WebApplication app, string route)
        where TRequest : IMediatedRequest
    {
        app.MapDelete(route, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));

        return app;
    }
}
