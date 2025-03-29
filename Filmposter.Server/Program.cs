using Filmposter.Persistence.Contexts;
using FilmPoster.Application.Interfaces.Contexts;
using FilmPoster.Application.Interfaces.FacadePattern;
using FilmPoster.Application.Servies.NationFilmPosters.FacadePattern;
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
builder.Services.AddScoped<INationFilmPostersFacade, NationFilmPostersFacadePattern>();


//SqlServer Provider
var environment = builder.Environment.EnvironmentName;
var ConStr = environment == "Development"
                       ? builder.Configuration.GetConnectionString("LocalServer")
                       : builder.Configuration.GetConnectionString("VpsServer");

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(x => x.UseSqlServer(ConStr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
