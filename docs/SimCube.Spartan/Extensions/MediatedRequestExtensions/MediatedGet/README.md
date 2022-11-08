# MediatedRequestExtensions\.MediatedGet\<TRequest\>\(WebApplication, String, Action\<RouteHandlerBuilder\>?, IReadOnlyCollection\<IEndpointFilter\>?, String?, String?\) Method

[Home](../../../../README.md)

**Containing Type**: [MediatedRequestExtensions](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Map Mediated Get requests to the specified controller action\.

```csharp
public static WebApplication MediatedGet<TRequest>(this WebApplication app, string route, Action<RouteHandlerBuilder>? configureEndpoint = null, IReadOnlyCollection<IEndpointFilter>? endpointFilters = null, string? namedCachePolicy = null, string? namedRateLimitPolicy = null) where TRequest : SimCube.Spartan.Interfaces.IMediatedRequest
```

### Type Parameters

**TRequest**

The type of the request to map with its parameters\.

### Parameters

**app** &ensp; WebApplication

The web application instance\.

**route** &ensp; System\.String

the route to map the request on\.

**configureEndpoint** &ensp; Action\<RouteHandlerBuilder\>?

The optional route handler configuration action for endpoint extension\.

**endpointFilters** &ensp; IReadOnlyCollection\<IEndpointFilter\>?

The optional Endpoint filters to chain to the request pipeline\.

**namedCachePolicy** &ensp; System\.String?

The optional named Output Cache Policy to use\.

**namedRateLimitPolicy** &ensp; System\.String?

The optional named Rate Limit Policy to use\.

### Returns

WebApplication

A type of **IResult**\.