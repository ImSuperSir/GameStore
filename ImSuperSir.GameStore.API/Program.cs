using ImSuperSir.GameStore.API.Entities;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var group = app.MapGroup("/games");

const string GetGameEndPointName = "GamesStore";

List<Game> games = new List<Game>() {
    new Game() {
        Id = 1,
        Name = "Juego de titanes",
        Genre="Accion",
        Price=3.99M,
        ReleaseDate = new DateTime(1976,04,16),
        ImageUri = "https://placehold.co/100"
    },
      new Game() {
        Id = 2,
        Name = "Rojo Car",
        Genre="Accion",
        Price=3.99M,
        ReleaseDate = new DateTime(1976,04,16),
        ImageUri = "https://placehold.co/100"
    },
      new Game() {
        Id = 3,
        Name = "Dance with wolfs",
        Genre="Accion",
        Price=3.99M,
        ReleaseDate = new DateTime(1976,04,16),
        ImageUri = "https://placehold.co/100"
    }
};


group.MapGet("/", () => { 
    return Results.Ok(games);
});

group.MapGet("/{id}", (int id) =>
{
    Game game = games.Find( x => x.Id == id);
    
    if(game == null) return Results.NotFound();

    return Results.Ok(game);


}).WithName(GetGameEndPointName);


group.MapPost("/", (Game game) => 
{

    game.Id = games.Max(x => x.Id) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id}, game);
});


group.MapPut("/{id}", (Game updatedGame, int id) =>
{
    Game existingGame = games.Find(x => x.Id == id);

    if (existingGame == null) return Results.NotFound();

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price  = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUri = updatedGame.ImageUri;

    return Results.NoContent();

});

group.MapDelete("/{id}", (int id) =>
{
    Game game = games.Find(x => x.Id == id);

    if (game != null)
    {
        games.Remove(game);
    }

    return Results.NoContent();

});


app.Run();
