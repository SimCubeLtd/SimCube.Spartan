# BaseMediatedStream\<TResult\> Class

[Home](../../../README.md) &#x2022; [Constructors](#constructors) &#x2022; [Properties](#properties) &#x2022; [Methods](#methods)

**Namespace**: [SimCube.Spartan.Requests](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Represents a base mediated stream\.

```csharp
[ExcludeFromCodeCoverage]
public abstract class BaseMediatedStream<TResult> : SimCube.Spartan.Interfaces.IMediatedStream<TResult>
```

### Type Parameters

**TResult**

The type of the result\.

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system) &#x2192; BaseMediatedStream\<TResult\>

### Attributes

* ExcludeFromCodeCoverage

### Implements

* [IMediatedStream](../../Interfaces/IMediatedStream-1/README.md)\<TResult\>
* MediatR\.IStreamRequest\<TResult\>

## Constructors

| Constructor | Summary |
| ----------- | ------- |
| [BaseMediatedStream()](-ctor/README.md) | |

## Properties

| Property | Summary |
| -------- | ------- |
| [EndpointFilters](EndpointFilters/README.md) | Gets the optional filters collection for endpoint middleware chaining via filters\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [ConfigureEndpoint()](ConfigureEndpoint/README.md) | Optionally Configures the Endpoint of the request\. |

