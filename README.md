
# Spartan

Testable Clean Minimal Apis, with Mediatr and Fluent Validation.

Utilising .Net 7's &nbsp;[AsParametersAttribute](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.asparametersattribute?view=aspnetcore-7.0)

&nbsp;

[![codecov](https://codecov.io/gh/SimCubeLtd/SimCube.Spartan/branch/main/graph/badge.svg?token=YW1VVMY0UK)](https://codecov.io/gh/SimCubeLtd/SimCube.Spartan) [![main](https://github.com/SimCubeLtd/SimCube.Spartan/actions/workflows/main.yml/badge.svg)](https://github.com/SimCubeLtd/SimCube.Spartan/actions/workflows/main.yml) ![Nuget](https://img.shields.io/nuget/v/SimCube.Spartan?style=flat-square)

&nbsp;

## Usage/Examples

### Using Attributes

#### Application Startup

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSpartanInfrastructure(x => x.AsScoped());
// Or pass through assemblies to scan for handlers
// builder.Services.AddSpartanInfrastructure(x => x.AsScoped(), typeof(MyAssemblyOne), typeof(MyAssemblyTwo));

var app = builder.Build();
app.AddMediatedEndpointsFromAttributes();
// Or pass through assemblies to scan for endpoints
// app.AddMediatedEndpointsFromAttributes(typeof(MyAssemblyOne), typeof(MyAssemblyTwo));

app.Run();
```

#### Request, Optional Validation and Handler

```csharp
[MediatedRequest(RequestType.MediatedGet, "example/{name}/{age}")]
public record GetExampleRequest(int Age, string Name) : IMediatedRequest;

public class GetExampleRequestValidator : AbstractValidator<GetExampleRequest>
{
    public GetExampleRequestValidator() =>
        RuleFor(x => x.Age)
            .GreaterThan(18)
            .WithMessage("You must be 18 to use this service.");
}

public class GetExampleRequestHandler : IRequestHandler<GetExampleRequest, IResult>
{
    public Task<IResult> Handle(GetExampleRequest request, CancellationToken cancellationToken) =>
        Task.FromResult(Results.Ok($"The age was {request.Age} and the name was {request.Name}"));
}
```

### Directly Using Extensions

#### Application Startup

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSpartanInfrastructure(x => x.AsScoped());
// Or pass through assemblies to scan for handlers
// builder.Services.AddSpartanInfrastructure(x => x.AsScoped(), typeof(MyAssemblyOne), typeof(MyAssemblyTwo));

var app = builder.Build();

app.AddMediatedEndpointsFromAttributes();
app.MediatedGet<GetExampleRequest>("example/{name}/{age}", routeHandlerBuilder => routeHandlerBuilder.WithName("GetExample"));
app.MediatedPatch<PatchExampleRequest>("example/{name}/{age}");

app.Run();
```

#### Request, Optional Validation and Handler

```csharp
public record GetExampleRequest(int Age, string Name) : IMediatedRequest;

public class GetExampleRequestValidator : AbstractValidator<GetExampleRequest>
{
    public GetExampleRequestValidator() =>
        RuleFor(x => x.Age)
            .GreaterThan(18)
            .WithMessage("You must be 18 to use this service.");
}

public class GetExampleRequestHandler : IRequestHandler<GetExampleRequest, IResult>
{
    public Task<IResult> Handle(GetExampleRequest request, CancellationToken cancellationToken) =>
        Task.FromResult(Results.Ok($"The age was {request.Age} and the name was {request.Name}"));
}
```

#### Requests can also derive from the BaseMediatedRequest class, and override the ConfigureEndpoint method to chain route endpoint configuration such as Cache, WithName, Produces etc

```csharp
[MediatedRequest(RequestType.MediatedDelete, "example/{name}/{age}")]
public class DeleteExampleRequest : BaseMediatedRequest
{
    public DeleteExampleRequest(int age, string name)
    {
        Age = age;
        Name = name;
    }

    public int Age { get; }

    public string Name { get; }

    public override Action<RouteHandlerBuilder> ConfigureEndpoint() => builder =>
        builder.AllowAnonymous()
            .WithName("DeleteStuff");
}
```



## Acknowledgements

- [Mediatr](https://github.com/jbogard/MediatR)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)
- [MIcrosoft](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [Nick Chapsas](https://www.youtube.com/c/Elfocrash)




## Authors

- [@prom3theu5](https://www.github.com/prom3theu5)
