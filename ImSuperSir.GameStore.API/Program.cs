using ImSuperSir.GameStore.API.EndPoints;
using ImSuperSir.GameStore.API.Entities;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGameEndPoints();

app.Run();
