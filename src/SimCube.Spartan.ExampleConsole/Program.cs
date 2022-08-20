using SimCube.Spartan.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSpartanInfrastructure(x => x.AsScoped(), true);

var app = builder.Build();

app.AddMediatedEndpointsFromAttributes();
app.MediatedGet<GetExampleRequest>("example/{name}/{age}", routeHandlerBuilder => routeHandlerBuilder.WithName("GetExample"));
app.MediatedPatch<PatchExampleRequest>("example/{name}/{age}");
app.Run();
