using ImSuperSir.GameStore.API.Authorization;
using ImSuperSir.GameStore.API.Data;
using ImSuperSir.GameStore.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddGameStoreAuthorization();

var app = builder.Build();

await app.Services.InitializaDbAsync();


app.MapGameEndPoints();

app.Run();
