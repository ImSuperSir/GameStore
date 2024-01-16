using ImSuperSir.GameStore.API.Authorization;
using ImSuperSir.GameStore.API.CORS;
using ImSuperSir.GameStore.API.Data;
using ImSuperSir.GameStore.API.EndPoints;
using ImSuperSir.GameStore.API.ErrorHandling;
using ImSuperSir.GameStore.API.Middleware;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddGameStoreAuthorization();

builder.Services.AddApiVersioning( options => {
    options.DefaultApiVersion = new(1.0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});


builder.Services.AddGameStoreCors(builder.Configuration);

builder.Services.AddHttpLogging(option => { });

var app = builder.Build();


//using the built-in exception handler
app.UseExceptionHandler((exceptionHandlerApp) => exceptionHandlerApp.ConfigureExceptionHandler());
app.UseMiddleware<RequestTimingMiddleware>();


await app.Services.InitializaDbAsync();


app.UseHttpLogging();

app.MapGameEndPoints();

app.UseCors();

app.Run();
