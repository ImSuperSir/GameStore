using ImSuperSir.GameStore.API.EndPoints;
using ImSuperSir.GameStore.API.Entities;
using ImSuperSir.GameStore.API.Repositories;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGamesRepository, InMemoryGamesRepository>();

var connString = builder.Configuration.GetConnectionString("GamesStoreContext");

var app = builder.Build();

app.MapGameEndPoints();

app.Run();
