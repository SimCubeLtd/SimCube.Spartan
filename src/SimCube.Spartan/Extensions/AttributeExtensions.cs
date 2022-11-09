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
    internal static void SetupMediatedRequestEndpointAttributes(this Attribute[]? attributes, Type request, IEndpointRouteBuilder app)
    {
        if (attributes?.FirstOrDefault(x => x is MediatedEndpointAttribute) is not MediatedEndpointAttribute mediatedRequestAttribute)
        {
            return;
        }

        if (mediatedRequestAttribute.IsGrouped && app is not RouteGroupBuilder)
        {
            return;
        }

        var configureMethod = request.GetMethod(nameof(BaseMediatedRequest.ConfigureEndpoint));
        var endpointFilters = request.GetProperty(nameof(BaseMediatedRequest.EndpointFilters));
        var cachePolicyName = GetCachedPolicyNameIfHasAttribute(attributes);
        var rateLimitPolicyName = GetRateLimitPolicyNameIfHasAttribute(attributes);

        CreateMediatedHandler(
            mediatedRequestAttribute,
            request,
            app,
            configureMethod,
            endpointFilters,
            cachePolicyName,
            rateLimitPolicyName);
    }

    private static void CreateMediatedHandler(
        MediatedEndpointAttribute mediatedEndpointAttribute,
        Type request,
        IEndpointRouteBuilder app,
        MethodBase? configureMethod,
        PropertyInfo? endpointFilters,
        string? cachedPolicyName,
        string? rateLimitPolicyName)
    {
        var (resultType, implementedType) = GetResultType(request);

        if (implementedType is ImplementedType.Unknown)
        {
            return;
        }

        var method = implementedType == ImplementedType.Request
            ? $"{mediatedEndpointAttribute.Method.ToString()}"
            : $"{mediatedEndpointAttribute.Method.ToString()}Stream";

        var methodInfo = resultType == null
            ? typeof(MediatedRequestExtensions).GetMethods().Single(x => x.Name == method && x.GetGenericArguments().Length == 1)
            : typeof(MediatedRequestExtensions).GetMethods().Single(x => x.Name == method && x.GetGenericArguments().Length == 2);

        var methodInstance = resultType is null
            ? methodInfo?.MakeGenericMethod(request)
            : methodInfo?.MakeGenericMethod(
                request,
                resultType);

        methodInstance?.Invoke(
            null,
            new object?[]
            {
                app,
                mediatedEndpointAttribute.Route,
                configureMethod?.Invoke(
                    FormatterServices.GetUninitializedObject(request),
                    Array.Empty<object>()) as Action<RouteHandlerBuilder>,
                endpointFilters?.GetValue(FormatterServices.GetUninitializedObject(request)) as List<IEndpointFilter>,
                cachedPolicyName,
                rateLimitPolicyName
            });
    }

    private static (Type? Type, ImplementedType ImplementedType) GetResultType(Type request)
    {
        var implementedInterfaces = request.GetInterfaces();

        if (request.InheritsFrom(typeof(IMediatedRequest<>)))
        {
            var interfaceInstance = Array.Find(implementedInterfaces, x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMediatedRequest<>));
            return (interfaceInstance?.GetGenericArguments().FirstOrDefault(), ImplementedType.Request);
        }

        if (request.InheritsFrom(typeof(IMediatedStream<>)))
        {
            var interfaceInstance = Array.Find(implementedInterfaces, x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMediatedStream<>));
            return (interfaceInstance?.GetGenericArguments().FirstOrDefault(), ImplementedType.Stream);
        }

        if (request.InheritsFrom(typeof(IMediatedRequest)))
        {
            return (null, ImplementedType.Request);
        }

        return (null, ImplementedType.Unknown);
    }

    private static Type? GetGenericInterface(Type[] interfacesOnType) =>
        Array.Find(
            interfacesOnType,
            x => x.IsGenericType &&
                 (x.GetGenericTypeDefinition() == typeof(IMediatedRequest<>) ||
                  x.GetGenericTypeDefinition() == typeof(IMediatedRequest<>)));

    private static string? GetCachedPolicyNameIfHasAttribute(Attribute[] attributes) =>
        attributes?.FirstOrDefault(x => x is CachePolicyAttribute) is not CachePolicyAttribute cachePolicyAttribute
            ? null
            : cachePolicyAttribute.PolicyName;

    private static string? GetRateLimitPolicyNameIfHasAttribute(Attribute[] attributes) =>
        attributes?.FirstOrDefault(x => x is RateLimitPolicyAttribute) is not RateLimitPolicyAttribute rateLimitPolicyAttribute
            ? null
            : rateLimitPolicyAttribute.PolicyName;
}
