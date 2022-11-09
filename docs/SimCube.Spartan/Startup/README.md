# Startup Class

[Home](../../README.md) &#x2022; [Methods](#methods)

**Namespace**: [SimCube.Spartan](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Startup extensions for Spartan\.

```csharp
[ExcludeFromCodeCoverage]
public static class Startup
```

### Attributes

* ExcludeFromCodeCoverage

## Methods

| Method | Summary |
| ------ | ------- |
| [AddFluentValidationForRequests(IServiceCollection, IEnumerable\<Assembly\>, ServiceLifetime, Func\<AssemblyScanResult, Boolean\>?)](AddFluentValidationForRequests/README.md) | Adds the validation services\. |
| [AddMediatedEndpointsFromAttributes(WebApplication, Type\[\])](AddMediatedEndpointsFromAttributes/README.md) | Adds the mediated endpoints defined by attributes\. |
| [AddMediatedEndpointsToGroup(RouteGroupBuilder, Type\[\])](AddMediatedEndpointsToGroup/README.md) | Adds the mediated endpoints to a group\. |
| [AddSpartanInfrastructure(IServiceCollection, Action\<MediatRServiceConfiguration\>, Boolean, Type\[\])](AddSpartanInfrastructure/README.md#3982198342) | Adds the spartan services to the application\. |
| [AddSpartanInfrastructure(IServiceCollection, Action\<MediatRServiceConfiguration\>, Type\[\])](AddSpartanInfrastructure/README.md#3657889565) | Adds the spartan services to the application\. |

