using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;
using System.Text.Json;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton(builder.HostEnvironment);
await builder.Build().RunAsync();