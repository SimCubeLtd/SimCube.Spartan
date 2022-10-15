using SimCube.Spartan.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSpartanInfrastructure(x => x.AsScoped(), true);
builder.Services.AddOutputCache(options =>
{
    options.AddPolicy(nameof(GetExampleCachedRequest), policyBuilder =>
    {
        policyBuilder.Cache()
            .Expire(TimeSpan.FromSeconds(10));
    });
});
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseStatusCodePages();
app.AddMediatedEndpointsFromAttributes();
app.UseOutputCache();
app.MediatedGet<GetExampleRequest>("example/{name}/{age}", routeHandlerBuilder => routeHandlerBuilder.WithName("GetExample"));
app.MediatedPatch<PatchExampleRequest>("example/{name}/{age}");
app.Run();
