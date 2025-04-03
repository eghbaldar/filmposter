using FIlmposter.Client.Pages;
using FIlmposter.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents();

// set API settings
builder.Services.AddHttpClient();
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FIlmposter.Client._Imports).Assembly);

app.Run();
