namespace SimCube.Spartan.Extensions;

/// <summary>
/// Extensions for Attributes used in Service Startup.
/// </summary>
[ExcludeFromCodeCoverage]
internal static class AttributeExtensions
{
    /// <summary>
    /// Sets up mediated attribute endpoints if the attribute is of type <see cref="MediatedEndpointAttribute"/>.
    /// </summary>
    /// <param name="attributes">The attributes to handle.</param>
    /// <param name="request">The type to handle.</param>
    /// <param name="app">The WebApplication instance.</param>
    internal static void SetupMediatedRequestEndpointAttributes(this Attribute[]? attributes, Type request, WebApplication app)
    {
        if (attributes?.FirstOrDefault(x => x is MediatedEndpointAttribute) is not MediatedEndpointAttribute mediatedRequestAttribute)
        {
            return;
        }

        var configureMethod = request.GetMethod(nameof(BaseMediatedRequest.ConfigureEndpoint));
        var endpointFilters = request.GetProperty(nameof(BaseMediatedRequest.EndpointFilters));
        var cachePolicyName = GetCachedPolicyNameIfHasAttribute(attributes);
        var rateLimitPolicyName = GetRateLimitPolicyNameIfHasAttribute(attributes);

        CreateMediatedHandler(mediatedRequestAttribute, request, app, configureMethod, endpointFilters, cachePolicyName, rateLimitPolicyName);
    }

    private static void CreateMediatedHandler(
        MediatedEndpointAttribute mediatedEndpointAttribute,
        Type request,
        WebApplication app,
        MethodBase? configureMethod,
        PropertyInfo? endpointFilters,
        string? cachedPolicyName,
        string? rateLimitPolicyName)
    {
        var resultType = GetResultType(request);

        var method = resultType is null
            ? $"{mediatedEndpointAttribute.Method.ToString()}"
            : $"{mediatedEndpointAttribute.Method.ToString()}Stream";

        var methodInfo = typeof(MediatedRequestExtensions).GetMethod(method);

        var methodInstance = resultType is null
            ? methodInfo?.MakeGenericMethod(request)
            : methodInfo?.MakeGenericMethod(request, resultType);

        methodInstance?.Invoke(
                null,
                new object?[]
                {
                    app,
                    mediatedEndpointAttribute.Route,
                    configureMethod?.Invoke(FormatterServices.GetUninitializedObject(request), Array.Empty<object>()) as Action<RouteHandlerBuilder>,
                    endpointFilters?.GetValue(FormatterServices.GetUninitializedObject(request)) as List<IEndpointFilter>,
                    cachedPolicyName,
                    rateLimitPolicyName
                });
    }

    private static Type? GetResultType(Type request)
    {
        if (!request.IsGenericType)
        {
            return null;
        }

        return Array.Find(request.GetInterfaces(), x => x.GetGenericTypeDefinition() == typeof(IMediatedStream<>))
            ?.GetGenericArguments().FirstOrDefault();
    }

    private static string? GetCachedPolicyNameIfHasAttribute(Attribute[] attributes) =>
        attributes?.FirstOrDefault(x => x is CachePolicyAttribute) is not CachePolicyAttribute cachePolicyAttribute
            ? null
            : cachePolicyAttribute.PolicyName;

    private static string? GetRateLimitPolicyNameIfHasAttribute(Attribute[] attributes) =>
        attributes?.FirstOrDefault(x => x is RateLimitPolicyAttribute) is not RateLimitPolicyAttribute rateLimitPolicyAttribute
            ? null
            : rateLimitPolicyAttribute.PolicyName;
}
