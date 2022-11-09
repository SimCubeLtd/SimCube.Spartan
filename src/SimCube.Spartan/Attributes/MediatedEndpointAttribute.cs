namespace SimCube.Spartan.Attributes;

/// <summary>
/// Attribute for registration of an Endpoint.
/// </summary>
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class MediatedEndpointAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediatedEndpointAttribute"/> class.
    /// </summary>
    /// <param name="method">The mediated request method.</param>
    /// <param name="route">The route to register the endpoint on.</param>
    /// <param name="isGrouped">Specifies if the endpoint should be mapped on the app, or within a group.</param>
    public MediatedEndpointAttribute(RequestType method, string route, bool isGrouped = false)
    {
        Method = method;
        Route = route;
        IsGrouped = isGrouped;
    }

    /// <summary>
    /// Gets a value indicating whether the endpoint is grouped.
    /// </summary>
    public bool IsGrouped { get; }

    /// <summary>
    /// Gets the type of the http request.
    /// </summary>
    public RequestType Method { get; }

    /// <summary>
    /// Gets the route of the endpoint.
    /// </summary>
    public string Route { get; }
}
