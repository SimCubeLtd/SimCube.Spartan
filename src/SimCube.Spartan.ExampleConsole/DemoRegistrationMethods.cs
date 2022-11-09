namespace SimCube.Spartan.ExampleConsole;

/// <summary>
/// This is a simple example of how to use the Spartan API.
/// </summary>
public static class DemoRegistrationMethods
{
    /// <summary>
    /// Adds support services used by the demo. Not Required directly by spartan.
    /// </summary>
    /// <param name="services">The services collection to populate.</param>
    /// <returns>The populated service collection.</returns>
    public static IServiceCollection RegisterRequiredServicesForDemo(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.Configure<SwaggerGeneratorOptions>(options => options.InferSecuritySchemes = true);

        services.AddOutputCache(options =>
        {
            options.AddPolicy(nameof(GetExampleCachedRequest), policyBuilder =>
            {
                policyBuilder.Cache()
                    .Expire(TimeSpan.FromSeconds(10));
            });
        });
        services.AddProblemDetails();

        return services;
    }

    /// <summary>
    /// This method shows how to manually register mediated requests.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <returns>The web application instance with the mediated requests mapped.</returns>
    public static WebApplication AddExampleManualMaps(this WebApplication app)
    {
        app.MediatedGet<GetExampleRequest>("example/{name}/{age}");
        app.MediatedPatch<PatchExampleRequest>("example/{name}/{age}");

        return app;
    }

    /// <summary>
    /// This method shows how to automatically register mediated requests using the attribute.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <returns>The web application instance with the mediated requests mapped.</returns>
    public static WebApplication AddExampleDiscoveredMaps(this WebApplication app)
    {
        app.AddMediatedEndpointsFromAttributes();

        return app;
    }

    /// <summary>
    /// This method shows how to add grouped mapping to the app route instance..
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <returns>The web application instance with the mediated requests mapped.</returns>
    public static WebApplication AddExampleGroupedMaps(this WebApplication app)
    {
        var group = app.MapGroup("/group-example");

        // Register the requests on the type array parameter if using the attribute, passing multiple types into the group (can be chained directly on the RouteBuilder instance).
        group.AddMediatedEndpointsToGroup(typeof(GetExampleGroupRequest));

        // Or manually register the requests on the group if they do not have the attribute.
        group.MediatedGet<GetExampleTwoGroupRequest>("/example-two/{name}/{age}");

        return app;
    }

    /// <summary>
    /// Adds support services used by the demo. Not Required directly by spartan.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <returns>The configured web application instance.</returns>
    public static WebApplication AddSupportServiceForDemoToApp(this WebApplication app)
    {
        app.UseStatusCodePages();
        app.UseOutputCache();
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
