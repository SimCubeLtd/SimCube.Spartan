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
    public static IServiceCollection AddSpartanInfrastructure(this IServiceCollection services, Action<MediatRServiceConfiguration> mediatorScope, params Type[] handlerAssemblyMarkerTypes) =>
        AddSpartanInfrastructure(services, mediatorScope, true, handlerAssemblyMarkerTypes: handlerAssemblyMarkerTypes);

    /// <summary>
    /// Adds the spartan services to the application.
    /// </summary>
    /// <param name="services">The service collection instance.</param>
    /// <param name="mediatorScope">The scope to use when registering handlers in Mediatr.</param>
    /// <param name="addFluentValidation">Should add fluent validation validators into the mediator pipeline?.</param>
    /// <param name="handlerAssemblyMarkerTypes">The custom assemblies to register (Executing assembly is always included).</param>
    /// <returns>The populated service collection.</returns>
    public static IServiceCollection AddSpartanInfrastructure(this IServiceCollection services, Action<MediatRServiceConfiguration> mediatorScope, bool addFluentValidation = true, params Type[] handlerAssemblyMarkerTypes)
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

        if (addFluentValidation)
        {
            services.AddFluentValidationForRequests(assemblies);
        }

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
        services.Add(new(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>), lifetime));
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

        var endpointsToDefine = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(type => type.GetCustomAttributes(typeof(MediatedEndpointAttribute), true).Length > 0)
            .ToArray();

        foreach (var request in endpointsToDefine)
        {
            Attribute
                .GetCustomAttributes(request)
                .SetupMediatedRequestEndpointAttributes(request, app);
        }

        return app;
    }

    /// <summary>
    /// Adds the mediated endpoints to a group.
    /// </summary>
    /// <param name="group">The group to map onto.</param>
    /// <param name="groupRequests">The mediated requests to map as group children.</param>
    /// <returns>The populated group builder instance.</returns>
    public static RouteGroupBuilder AddMediatedEndpointsToGroup(this RouteGroupBuilder group, params Type[] groupRequests)
    {
        if (groupRequests.Length == 0)
        {
            throw new InvalidOperationException("No group markers were provided.");
        }

        var endpointsToDefine = groupRequests
            .Where(type => type.BaseType == typeof(BaseMediatedRequest) &&
                           type.GetCustomAttributes(typeof(MediatedEndpointAttribute), true).Length > 0)
            .ToArray();

        var requests = endpointsToDefine
            .Where(type => type.GetInterfaces().Contains(typeof(IMediatedRequest))
                           || (type.IsGenericType && type.GetInterfaces().Contains(typeof(IMediatedStream<>)))).ToArray();

        foreach (var request in requests)
        {
            Attribute
                .GetCustomAttributes(request)
                .SetupMediatedRequestEndpointAttributes(request, group);
        }

        return group;
    }
}
