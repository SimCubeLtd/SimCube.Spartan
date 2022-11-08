# ValidationBehavior\<TRequest, TResponse\> Class

[Home](../../../README.md) &#x2022; [Constructors](#constructors) &#x2022; [Methods](#methods)

**Namespace**: [SimCube.Spartan.Validation](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Validation rules for mediated requests\.

```csharp
[ExcludeFromCodeCoverage]
public class ValidationBehavior<TRequest, TResponse> : MediatR.IPipelineBehavior<TRequest, TResponse>
    where TRequest : MediatR.IRequest<TResponse> 
    where TResponse : IResult
```

### Type Parameters

**TRequest**

The type of the request\.

**TResponse**

The response type\.

### Inheritance

[Object](https://docs.microsoft.com/en-us/dotnet/api/system) &#x2192; ValidationBehavior\<TRequest, TResponse\>

### Attributes

* ExcludeFromCodeCoverage

### Implements

* MediatR\.IPipelineBehavior\<TRequest, TResponse\>

## Constructors

| Constructor | Summary |
| ----------- | ------- |
| [ValidationBehavior(IEnumerable\<IValidator\<TRequest\>\>)](-ctor/README.md) | Initializes a new instance of the [ValidationBehavior\<TRequest, TResponse\>](./README.md) class\. |

## Methods

| Method | Summary |
| ------ | ------- |
| [Handle(TRequest, RequestHandlerDelegate\<TResponse\>, CancellationToken)](Handle/README.md) | Performs the validation\. |

