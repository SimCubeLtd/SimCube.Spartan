# MediatedEndpointAttribute\(RequestType, String, Boolean\) Constructor

[Home](../../../../README.md)

**Containing Type**: [MediatedEndpointAttribute](../README.md)

**Assembly**: SimCube\.Spartan\.dll

  
Initializes a new instance of the [MediatedEndpointAttribute](../README.md) class\.

```csharp
public MediatedEndpointAttribute(SimCube.Spartan.Enums.RequestType method, string route, bool isGrouped = false)
```

### Parameters

**method** &ensp; [RequestType](../../../Enums/RequestType/README.md)

The mediated request method\.

**route** &ensp; System\.String

The route to register the endpoint on\.

**isGrouped** &ensp; System\.Boolean

Specifies if the endpoint should be mapped on the app, or within a group\.