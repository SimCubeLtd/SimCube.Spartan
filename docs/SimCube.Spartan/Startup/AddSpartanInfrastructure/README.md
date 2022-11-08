# Startup\.AddSpartanInfrastructure Method

[Home](../../../README.md)

**Containing Type**: [Startup](../README.md)

**Assembly**: SimCube\.Spartan\.dll

## Overloads

| Method | Summary |
| ------ | ------- |
| [AddSpartanInfrastructure(IServiceCollection, Action\<MediatRServiceConfiguration\>, Boolean, Type\[\])](#3982198342) | Adds the spartan services to the application\. |
| [AddSpartanInfrastructure(IServiceCollection, Action\<MediatRServiceConfiguration\>, Type\[\])](#3657889565) | Adds the spartan services to the application\. |

<a id="3982198342"></a>

## AddSpartanInfrastructure\(IServiceCollection, Action\<MediatRServiceConfiguration\>, Boolean, Type\[\]\) 

  
Adds the spartan services to the application\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddSpartanInfrastructure(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<MediatR.MediatRServiceConfiguration> mediatorScope, bool addFluentValidation = true, params Type[] handlerAssemblyMarkerTypes)
```

### Parameters

**services** &ensp; [IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection)

The service collection instance\.

**mediatorScope** &ensp; Action\<MediatRServiceConfiguration\>

The scope to use when registering handlers in Mediatr\.

**addFluentValidation** &ensp; System\.Boolean

Should add fluent validation validators into the mediator pipeline?\.

**handlerAssemblyMarkerTypes** &ensp; Type\[\]

The custom assemblies to register \(Executing assembly is always included\)\.

### Returns

[IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection)

The populated service collection\.<a id="3657889565"></a>

## AddSpartanInfrastructure\(IServiceCollection, Action\<MediatRServiceConfiguration\>, Type\[\]\) 

  
Adds the spartan services to the application\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddSpartanInfrastructure(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<MediatR.MediatRServiceConfiguration> mediatorScope, params Type[] handlerAssemblyMarkerTypes)
```

### Parameters

**services** &ensp; [IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection)

The service collection instance\.

**mediatorScope** &ensp; Action\<MediatRServiceConfiguration\>

The scope to use when registering handlers in Mediatr\.

**handlerAssemblyMarkerTypes** &ensp; Type\[\]

The custom assemblies to register \(Executing assembly is always included\)\.

### Returns

[IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection)

The populated service collection\.