# BaseMediatedRequest\<TResult\> Class

[Home](../../../README.md) &#x2022; [Constructors](#constructors) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods)

**Namespace**: [SimCube.Spartan.Requests](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Base request for all mediated requests\.

```csharp
[ExcludeFromCodeCoverage]
public abstract class BaseMediatedRequest<TResult> : SimCube.Spartan.Interfaces.IMediatedRequest<TResult>
```

### Type Parameters

**TResult**

The type of the result\.

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system) &#x2192; BaseMediatedRequest\<TResult\>

### Attributes

* ExcludeFromCodeCoverage

### Implements

* MediatR\.IBaseRequest
* [IMediatedRequest](../../Interfaces/IMediatedRequest-1/README.md)\<TResult\>
* MediatR\.IRequest\<TResult\>

## Constructors

| Constructor | Summary |
| ----------- | ------- |
| [BaseMediatedRequest()](-ctor/README.md) | |

## Properties

| Property | Summary |
| -------- | ------- |
| [EndpointFilters](EndpointFilters/README.md) | Gets the optional filters collection for endpoint middleware chaining via filters\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [ConfigureEndpoint()](ConfigureEndpoint/README.md) | Optionally Configures the Endpoint of the request\. |

