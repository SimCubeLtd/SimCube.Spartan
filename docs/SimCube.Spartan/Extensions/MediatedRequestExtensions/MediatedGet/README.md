# MediatedRequestExtensions\.MediatedGet Method

[Home](../../../../README.md)

**Containing Type**: [MediatedRequestExtensions](../README.md)

**Assembly**: SimCube\.Spartan\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [MediatedGet\<TRequest, TResult\>(IEndpointRouteBuilder, String, Action\<RouteHandlerBuilder\>?, IReadOnlyCollection\<IEndpointFilter\>?, String?, String?)](#3239312544) | Map Mediated Get requests to the specified controller action\. |
| [MediatedGet\<TRequest\>(IEndpointRouteBuilder, String, Action\<RouteHandlerBuilder\>?, IReadOnlyCollection\<IEndpointFilter\>?, String?, String?)](#2423506945) | Map Mediated Get requests to the specified controller action\. |

<a id="3239312544"></a>

## MediatedGet\<TRequest, TResult\>\(IEndpointRouteBuilder, String, Action\<RouteHandlerBuilder\>?, IReadOnlyCollection\<IEndpointFilter\>?, String?, String?\) 

  
Map Mediated Get requests to the specified controller action\.

```csharp
public static IEndpointRouteBuilder MediatedGet<TRequest, TResult>(this IEndpointRouteBuilder app, string route, Action<RouteHandlerBuilder>? configureEndpoint = null, IReadOnlyCollection<IEndpointFilter>? endpointFilters = null, string? namedCachePolicy = null, string? namedRateLimitPolicy = null) where TRequest : SimCube.Spartan.Interfaces.IMediatedRequest<TResult>
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

A type of **IResult**\.<a id="2423506945"></a>

## MediatedGet\<TRequest\>\(IEndpointRouteBuilder, String, Action\<RouteHandlerBuilder\>?, IReadOnlyCollection\<IEndpointFilter\>?, String?, String?\) 

  
Map Mediated Get requests to the specified controller action\.

```csharp
public static IEndpointRouteBuilder MediatedGet<TRequest>(this IEndpointRouteBuilder app, string route, Action<RouteHandlerBuilder>? configureEndpoint = null, IReadOnlyCollection<IEndpointFilter>? endpointFilters = null, string? namedCachePolicy = null, string? namedRateLimitPolicy = null) where TRequest : SimCube.Spartan.Interfaces.IMediatedRequest<IResult>
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