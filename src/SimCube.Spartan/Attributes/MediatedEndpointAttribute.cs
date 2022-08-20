namespace SimCube.Spartan.Attributes;

/// <summary>
/// Attribute for registration of an Endpoint.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class MediatedEndpointAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediatedEndpointAttribute"/> class.
    /// </summary>
    /// <param name="method">The mediated request method.</param>
    /// <param name="route">The route to register the endpoint on.</param>
    public MediatedEndpointAttribute(RequestType method, string route)
    {
        Method = method;
        Route = route;
    }

    /// <summary>
    /// Gets the type of the http request.
    /// </summary>
    public RequestType Method { get; }

    /// <summary>
    /// Gets the route of the endpoint.
    /// </summary>
    public string Route { get; }
}
