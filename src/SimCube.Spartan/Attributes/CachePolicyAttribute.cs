namespace SimCube.Spartan.Attributes;

/// <summary>
/// Attribute for Cache Output Policy Setup on an Endpoint.
/// </summary>
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class CachePolicyAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CachePolicyAttribute"/> class.
    /// </summary>
    /// <param name="policyName">The Policy Name.</param>
    public CachePolicyAttribute(string policyName) => PolicyName = policyName;

    /// <summary>
    /// Gets the type of the http request.
    /// </summary>
    public string PolicyName { get; }
}
