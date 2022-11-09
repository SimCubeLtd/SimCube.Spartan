var builder = WebApplication.CreateBuilder(args);

// Register Support Services.
builder.Services.RegisterRequiredServicesForDemo();

// Add Spartan.Services to the container.
builder.Services.AddSpartanInfrastructure(x => x.AsScoped(), true);

// Create a WebApplication Instance from the Builder.
var app = builder.Build();

// Setup support services on the app.
app.AddSupportServiceForDemoToApp();

// Demo Registrations using Spartan.
app.AddExampleDiscoveredMaps();
app.AddExampleManualMaps();
app.AddExampleGroupedMaps();

// Run the WebHost.
app.Run();
