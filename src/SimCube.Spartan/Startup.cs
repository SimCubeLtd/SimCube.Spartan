namespace SimCube.Spartan;

/// <summary>
/// Startup extensions for Spartan.
/// </summary>
[ExcludeFromCodeCoverage]
public static class Startup
{
    /// <summary>
    /// Adds the spartan services to the application.
    /// </summary>
    /// <param name="services">The service collection instance.</param>
    /// <param name="mediatorScope">The scope to use when registering handlers in Mediatr.</param>
    /// <param name="handlerAssemblyMarkerTypes">The custom assemblies to register (Executing assembly is always included).</param>
    /// <returns>The populated service collection.</returns>
    public static IServiceCollection AddSpartanInfrastructure(this IServiceCollection services, Action<MediatRServiceConfiguration> mediatorScope, params Type[] handlerAssemblyMarkerTypes)
    {
        var assemblies = new[]
        {
            Assembly.GetCallingAssembly(),
        };

        if (handlerAssemblyMarkerTypes.Length > 0)
        {
            assemblies = assemblies.Concat(handlerAssemblyMarkerTypes
                .Select(t => t.GetTypeInfo().Assembly))
                .ToArray();
        }

        services.AddFluentValidationForRequests(assemblies);

        services.AddMediatR(mediatorScope, assemblies);

        return services;
    }

    /// <summary>
    /// Adds the validation services.
    /// </summary>
    /// <param name="services">The service collection instance.</param>
    /// <param name="assemblies">The assemblies to register.</param>
    /// <param name="lifetime">The lifetime to register as, defaults to transient.</param>
    /// <param name="filter">The assembly scanner filter.</param>
    /// <returns>The populated service collection with validators registered.</returns>
    public static IServiceCollection AddFluentValidationForRequests(
        this IServiceCollection services,
        IEnumerable<Assembly> assemblies,
        ServiceLifetime lifetime = ServiceLifetime.Transient,
        Func<AssemblyScanner.AssemblyScanResult, bool>? filter = null)
    {
        services.Add(new ServiceDescriptor(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>), lifetime));
        services.AddValidatorsFromAssemblies(assemblies, lifetime, filter);

        return services;
    }

    /// <summary>
    /// Adds the mediated endpoints defined by attributes.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <param name="handlerAssemblyMarkerTypes">The assemblies to look for attributes in.</param>
    /// <returns>The populated web application instance.</returns>
    public static WebApplication AddMediatedEndpointsFromAttributes(this WebApplication app, params Type[] handlerAssemblyMarkerTypes)
    {
        var assemblies = new[]
        {
            Assembly.GetCallingAssembly(),
        };

        if (handlerAssemblyMarkerTypes.Length > 0)
        {
            assemblies = assemblies.Concat(handlerAssemblyMarkerTypes
                    .Select(t => t.GetTypeInfo().Assembly))
                .ToArray();
        }

        var requests = assemblies.SelectMany(x => x.GetTypes())
                .Where(type => type.GetCustomAttributes(typeof(MediatedRequestAttribute), true).Length > 0 &&
                               type.GetInterfaces().Contains(typeof(IMediatedRequest)));

        app.RegisterRequestEndpoints(requests);

        return app;
    }

    private static void RegisterRequestEndpoints(this WebApplication app, IEnumerable<Type> requests)
    {
        foreach (var request in requests)
        {
            var attribute = Attribute.GetCustomAttribute(request, typeof(MediatedRequestAttribute));

            if (attribute is MediatedRequestAttribute mediatedRequestAttribute)
            {
                MapGenericMediatedEndpoint(app, request, mediatedRequestAttribute);
            }
        }
    }

    private static void MapGenericMediatedEndpoint(WebApplication app, Type request, MediatedRequestAttribute mediatedRequestAttribute)
    {
        Action<RouteHandlerBuilder>? configureAction = null;
        var configureMethod = request.GetMethod("ConfigureEndpoint");

        if (request.IsSubclassOf(typeof(BaseMediatedRequest)) && configureMethod is not null)
        {
            configureAction = (FormatterServices.GetUninitializedObject(request) as BaseMediatedRequest)?.ConfigureEndpoint();
        }

        typeof(MediatedExtensions)
            .GetMethod(mediatedRequestAttribute.Method.ToString())?
            .MakeGenericMethod(request)
            .Invoke(null, new object?[] { app, mediatedRequestAttribute.Route, configureAction });
    }
}
