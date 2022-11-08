# IMediatedStream\<TResult\> Interface

[Home](../../../README.md)

**Namespace**: [SimCube.Spartan.Interfaces](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Interface for the Mediated Stream Requests\.

```csharp
public interface IMediatedStream<out TResult> : MediatR.IStreamRequest<TResult>
```

### Type Parameters

**TResult**

The result type for Streamed Results\.

### Derived

* [BaseMediatedStream\<TResult\>](../../Requests/BaseMediatedStream-1/README.md)

### Implements

* MediatR\.IStreamRequest\<TResult\>
