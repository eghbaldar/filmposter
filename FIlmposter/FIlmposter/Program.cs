using FIlmposter.Client.Pages;
using FIlmposter.Components;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents();

// set API settings
builder.Services.AddHttpClient();
// Keep your existing server configuration
//builder.Services.AddHttpClient("ServerApi", client =>
//{
//    var environment = builder.Environment;
//    client.BaseAddress = new Uri(environment.IsDevelopment()
//        ? builder.Configuration["ApiBaseUrl_Localhost"]!
//        : builder.Configuration["ApiBaseUrl_Server"]!);
//});
// Configure HttpClient with API base address (Necessary!)
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7104") // API's URL
    });

// Add CORS services (Necessary)
var corsPolicyName = "AllowBlazorClient";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        policy =>
        {
            policy.WithOrigins(
                    "https://localhost:7104",  // Your Blazor app
                    "http://localhost:5274",  // Optional HTTP fallback
                    "https://localhost:5001",  // Common Blazor ports
                    "http://localhost:5000")   // Common Blazor ports
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseCors("AllowBlazorClient"); // (Necessary)

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FIlmposter.Client._Imports).Assembly);

app.Run();
