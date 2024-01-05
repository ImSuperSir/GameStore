using ImSuperSir.GameStore.API.Entities;
using ImSuperSir.GameStore.API.Repositories;

namespace ImSuperSir.GameStore.API.EndPoints
{
    public static class GameEndPoints
    {

        const string GetGameEndPointName = "GamesStore";

        
        public static RouteGroupBuilder MapGameEndPoints(this IEndpointRouteBuilder routes)
        {
            InMemoryGamesRepository repository = new InMemoryGamesRepository();

            var group = routes.MapGroup("/games").WithParameterValidation();

            group.MapGet("/", () =>
            {
                //TODO: check for when the list is empty
                return Results.Ok(repository.GetAll());
            });

            group.MapGet("/{id}", (int id) =>
            {
                Game? game = repository.GetGameById(id);
                return game != null ? Results.Ok(game) : Results.NotFound();

            }).WithName(GetGameEndPointName);

            group.MapPost("/", (Game game) =>
            {
                repository.Create(game);
                return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);

            });

            group.MapPut("/{id}", (Game updatedGame, int id) =>
            {
                Game existingGame = repository.GetGameById(id);

                if (existingGame == null) return Results.NotFound();

                existingGame.Name = updatedGame.Name;
                existingGame.Genre = updatedGame.Genre;
                existingGame.Price = updatedGame.Price;
                existingGame.ReleaseDate = updatedGame.ReleaseDate;
                existingGame.ImageUri = updatedGame.ImageUri;

                repository.Update(existingGame);

                return Results.NoContent();

            });

            group.MapDelete("/{id}", (int id) =>
            {
                Game game = repository.GetGameById(id); 

                if (game != null)
                {
                    repository.Delete(id);
                }

                return Results.NoContent();

            });

            return group;
        }
    }
}


