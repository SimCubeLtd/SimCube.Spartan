# Startup\.AddFluentValidationForRequests\(IServiceCollection, IEnumerable\<Assembly\>, ServiceLifetime, Func\<AssemblyScanner\.AssemblyScanResult, Boolean\>?\) Method

[Home](../../../README.md)

**Containing Type**: [Startup](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Adds the validation services\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddFluentValidationForRequests(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, IEnumerable<Assembly> assemblies, Microsoft.Extensions.DependencyInjection.ServiceLifetime lifetime = null, Func<FluentValidation.AssemblyScanner.AssemblyScanResult, bool>? filter = null)
```

### Parameters

**services** &ensp; [IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection)

The service collection instance\.

**assemblies** &ensp; IEnumerable\<Assembly\>

The assemblies to register\.

**lifetime** &ensp; [ServiceLifetime](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime)

The lifetime to register as, defaults to transient\.

**filter** &ensp; Func\<AssemblyScanner\.AssemblyScanResult, System\.Boolean\>?

The assembly scanner filter\.

### Returns

[IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection)

The populated service collection with validators registered\.