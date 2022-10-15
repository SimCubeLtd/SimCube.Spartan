﻿namespace SimCube.Spartan.Attributes;

/// <summary>
/// Attribute for Rate Limiting Policy setup on an Endpoint.
/// </summary>
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class RateLimitPolicyAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RateLimitPolicyAttribute"/> class.
    /// </summary>
    /// <param name="policyName">The Policy Name.</param>
    public RateLimitPolicyAttribute(string policyName) => PolicyName = policyName;

    /// <summary>
    /// Gets the type of the http request.
    /// </summary>
    public string PolicyName { get; }
}
