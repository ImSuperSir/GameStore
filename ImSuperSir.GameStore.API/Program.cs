using ImSuperSir.GameStore.API.Authorization;
using ImSuperSir.GameStore.API.Data;
using ImSuperSir.GameStore.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddGameStoreAuthorization();


//I've commented this, 'cause it is too verbose..

//builder.Logging.AddJsonConsole(options => {

//    options.JsonWriterOptions = new() {
//        Indented = true
//    };
//});

builder.Services.AddHttpLogging( opttion => { } );

var app = builder.Build();

await app.Services.InitializaDbAsync();
//app.Logger.LogInformation("the database is ready...");

app.UseHttpLogging();

app.MapGameEndPoints();

app.Run();
