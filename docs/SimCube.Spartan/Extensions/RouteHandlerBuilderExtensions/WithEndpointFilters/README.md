# RouteHandlerBuilderExtensions\.WithEndpointFilters\(IEndpointConventionBuilder, IEnumerable\<IEndpointFilter\>\) Method

[Home](../../../../README.md)

**Containing Type**: [RouteHandlerBuilderExtensions](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Chain the endpoint filters onto the route handler\.

```csharp
public static IEndpointConventionBuilder WithEndpointFilters(this IEndpointConventionBuilder builder, IEnumerable<IEndpointFilter> filters)
```

### Parameters

**builder** &ensp; IEndpointConventionBuilder

The route handler instance\.

**filters** &ensp; IEnumerable\<IEndpointFilter\>

The filters to chain\.

### Returns

IEndpointConventionBuilder

The endpoint with chained filters\.