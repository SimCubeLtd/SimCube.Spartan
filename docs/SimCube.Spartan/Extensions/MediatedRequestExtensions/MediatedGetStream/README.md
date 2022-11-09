# MediatedRequestExtensions\.MediatedGetStream\<TRequest, TResult\>\(IEndpointRouteBuilder, String, Action\<RouteHandlerBuilder\>?, IReadOnlyCollection\<IEndpointFilter\>?, String?, String?\) Method

[Home](../../../../README.md)

**Containing Type**: [MediatedRequestExtensions](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Map Mediated Get streams to the specified controller action\.

```csharp
public static IEndpointRouteBuilder MediatedGetStream<TRequest, TResult>(this IEndpointRouteBuilder app, string route, Action<RouteHandlerBuilder>? configureEndpoint = null, IReadOnlyCollection<IEndpointFilter>? endpointFilters = null, string? namedCachePolicy = null, string? namedRateLimitPolicy = null) where TRequest : SimCube.Spartan.Interfaces.IMediatedStream<TResult>
```

### Type Parameters

**TRequest**

The type of the request to map with its parameters\.

**TResult**

The type of the result\.

### Parameters

**app** &ensp; IEndpointRouteBuilder

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

IEndpointRouteBuilder

A type of **IResult**\.