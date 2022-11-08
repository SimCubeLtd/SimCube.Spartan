# ValidationBehavior\<TRequest, TResponse\>\.Handle\(TRequest, RequestHandlerDelegate\<TResponse\>, CancellationToken\) Method

[Home](../../../../README.md)

**Containing Type**: [ValidationBehavior\<TRequest, TResponse\>](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Performs the validation\.

```csharp
public Task<TResponse> Handle(TRequest request, MediatR.RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
```

### Parameters

**request** &ensp; TRequest

The request to validate\.

**next** &ensp; RequestHandlerDelegate\<TResponse\>

The next middleware in the request pipeline\.

**cancellationToken** &ensp; CancellationToken

The cancellation token\.

### Returns

Task\<TResponse\>

The result of the validation, or the result of the next result in the pipeline if validation is successful\.