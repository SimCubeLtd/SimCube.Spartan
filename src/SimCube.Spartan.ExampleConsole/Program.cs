using SimCube.Spartan.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSpartanInfrastructure(x => x.AsScoped());

var app = builder.Build();

app.AddMediatedEndpointsFromAttributes();

// app.MediatedGet<GetExampleRequest>("example2/{name}/{age}");

// app.MediatedPost<PostExampleRequest>("example2/{name}/{age}");
app.Run();
