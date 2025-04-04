using Filmposter.Infrastructure.MappingProfiles.FilmPosters;
using Filmposter.Persistence.Contexts;
using FilmPoster.Application.Interfaces.Contexts;
using FilmPoster.Application.Interfaces.FacadePattern;
using FilmPoster.Application.Servies.FilmPosters.FacadePattern;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Context Interface
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
// Services
builder.Services.AddScoped<IFilmPostersFacade, FilmPostersFacadePattern>();
//SqlServer Provider
var environment = builder.Environment.EnvironmentName;
var ConStr = environment == "Development"
                       ? builder.Configuration.GetConnectionString("LocalServer")
                       : builder.Configuration.GetConnectionString("VpsServer");
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(x => x.UseSqlServer(ConStr));

// Mapping
builder.Services.AddAutoMapper(typeof(FilmPostersProfile));

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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazorClient"); // (Necessary)

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
