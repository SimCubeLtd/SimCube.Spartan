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

        var endpointsToDefine = assemblies.SelectMany(x => x.GetTypes()).Where(type => type.GetCustomAttributes(typeof(MediatedEndpointAttribute), true).Length > 0).ToArray();
        var requests = endpointsToDefine.Where(type => type.GetInterfaces().Contains(typeof(IMediatedRequest))).ToArray();
        var streams = endpointsToDefine.Except(requests).Where(stream => stream.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMediatedStream<>))).ToArray();

        app.RegisterRequestEndpoints(requests, streams);

        return app;
    }

    private static void RegisterRequestEndpoints(this WebApplication app, IEnumerable<Type> requests, IEnumerable<Type> streams)
    {
        foreach (var request in requests)
        {
            var attribute = Attribute.GetCustomAttribute(request, typeof(MediatedEndpointAttribute));

            if (attribute is MediatedEndpointAttribute mediatedRequestAttribute)
            {
                var configureMethod = request.GetMethod(nameof(BaseMediatedRequest.ConfigureEndpoint));
                var endpointFilters = request.GetProperty(nameof(BaseMediatedRequest.EndpointFilters));

                typeof(MediatedRequestExtensions)
                    .GetMethod(mediatedRequestAttribute.Method.ToString())?
                    .MakeGenericMethod(request)
                    .Invoke(null, new object?[]
                    {
                        app,
                        mediatedRequestAttribute.Route,
                        configureMethod?.Invoke(FormatterServices.GetUninitializedObject(request), Array.Empty<object>()) as Action<RouteHandlerBuilder>,
                        endpointFilters?.GetValue(FormatterServices.GetUninitializedObject(request)) as List<IEndpointFilter>,
                    });
            }
        }

        foreach (var stream in streams)
        {
            var attribute = Attribute.GetCustomAttribute(stream, typeof(MediatedEndpointAttribute));

            if (attribute is MediatedEndpointAttribute mediatedRequestAttribute)
            {
                var configureMethod = stream.GetMethod(nameof(BaseMediatedRequest.ConfigureEndpoint));
                var endpointFilters = stream.GetProperty(nameof(BaseMediatedRequest.EndpointFilters));

                var resultType = Array.Find(stream.GetInterfaces(), x => x.GetGenericTypeDefinition() == typeof(IMediatedStream<>))
                    ?.GetGenericArguments().FirstOrDefault();

                if (resultType is null)
                {
                    continue;
                }

                typeof(MediatedStreamExtensions)
                    .GetMethod($"{mediatedRequestAttribute.Method.ToString()}Stream")?
                    .MakeGenericMethod(stream, resultType)
                    .Invoke(null, new object?[]
                    {
                        app,
                        mediatedRequestAttribute.Route,
                        configureMethod?.Invoke(FormatterServices.GetUninitializedObject(stream), Array.Empty<object>()) as Action<RouteHandlerBuilder>,
                        endpointFilters?.GetValue(FormatterServices.GetUninitializedObject(stream)) as List<IEndpointFilter>,
                    });
            }
        }
    }
}
