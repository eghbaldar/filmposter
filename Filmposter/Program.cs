using Filmposter.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddHttpClient();

// set API settings
var environment = builder.Environment.EnvironmentName;
string apiBaseUrl;
if (environment == "Development")
{
    apiBaseUrl = builder.Configuration["ApiBaseUrl_Localhost"]; // Local API URL
}
else if (environment == "Production")
{
    apiBaseUrl = builder.Configuration["ApiBaseUrl_Server"]; // Production (server) API URL
}
else
{
    throw new Exception("Unknown environment: " + environment);
}
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
