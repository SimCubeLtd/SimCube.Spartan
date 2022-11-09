# Startup\.AddMediatedEndpointsToGroup\(RouteGroupBuilder, Type\[\]\) Method

[Home](../../../README.md)

**Containing Type**: [Startup](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Adds the mediated endpoints to a group\.

```csharp
public static RouteGroupBuilder AddMediatedEndpointsToGroup(this RouteGroupBuilder group, params Type[] groupRequests)
```

### Parameters

**group** &ensp; RouteGroupBuilder

The group to map onto\.

**groupRequests** &ensp; Type\[\]

The mediated requests to map as group children\.

### Returns

RouteGroupBuilder

The populated group builder instance\.