# MediatedRequestExtensions\.MediatedDelete Method

[Home](../../../../README.md)

**Containing Type**: [MediatedRequestExtensions](../README.md)

**Assembly**: SimCube\.Spartan\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [MediatedDelete\<TRequest, TResult\>(IEndpointRouteBuilder, String, Action\<RouteHandlerBuilder\>?, IReadOnlyCollection\<IEndpointFilter\>?, String?, String?)](#1238068732) | Map Mediated Delete requests to the specified controller action\. |
| [MediatedDelete\<TRequest\>(IEndpointRouteBuilder, String, Action\<RouteHandlerBuilder\>?, IReadOnlyCollection\<IEndpointFilter\>?, String?, String?)](#2165280052) | Map Mediated Delete requests to the specified controller action\. |

<a id="1238068732"></a>

## MediatedDelete\<TRequest, TResult\>\(IEndpointRouteBuilder, String, Action\<RouteHandlerBuilder\>?, IReadOnlyCollection\<IEndpointFilter\>?, String?, String?\) 

  
Map Mediated Delete requests to the specified controller action\.

```csharp
public static IEndpointRouteBuilder MediatedDelete<TRequest, TResult>(this IEndpointRouteBuilder app, string route, Action<RouteHandlerBuilder>? configureEndpoint = null, IReadOnlyCollection<IEndpointFilter>? endpointFilters = null, string? namedCachePolicy = null, string? namedRateLimitPolicy = null) where TRequest : SimCube.Spartan.Interfaces.IMediatedRequest<TResult>
```

### Type Parameters

**TRequest**

The type of the request to map with its parameters\.

**TResult**

The optional result type\.

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

A type of **IResult**\.<a id="2165280052"></a>

## MediatedDelete\<TRequest\>\(IEndpointRouteBuilder, String, Action\<RouteHandlerBuilder\>?, IReadOnlyCollection\<IEndpointFilter\>?, String?, String?\) 

  
Map Mediated Delete requests to the specified controller action\.

```csharp
public static IEndpointRouteBuilder MediatedDelete<TRequest>(this IEndpointRouteBuilder app, string route, Action<RouteHandlerBuilder>? configureEndpoint = null, IReadOnlyCollection<IEndpointFilter>? endpointFilters = null, string? namedCachePolicy = null, string? namedRateLimitPolicy = null) where TRequest : SimCube.Spartan.Interfaces.IMediatedRequest<IResult>
```

### Type Parameters

**TRequest**

The type of the request to map with its parameters\.

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