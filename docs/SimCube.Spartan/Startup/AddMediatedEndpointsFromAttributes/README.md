# Startup\.AddMediatedEndpointsFromAttributes\(WebApplication, Type\[\]\) Method

[Home](../../../README.md)

**Containing Type**: [Startup](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Adds the mediated endpoints defined by attributes\.

```csharp
public static WebApplication AddMediatedEndpointsFromAttributes(this WebApplication app, params Type[] handlerAssemblyMarkerTypes)
```

### Parameters

**app** &ensp; WebApplication

The web application instance\.

**handlerAssemblyMarkerTypes** &ensp; Type\[\]

The assemblies to look for attributes in\.

### Returns

WebApplication

The populated web application instance\.