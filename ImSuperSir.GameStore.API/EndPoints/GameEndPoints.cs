using ImSuperSir.GameStore.API.Authorization;
using ImSuperSir.GameStore.API.DTOs;
using ImSuperSir.GameStore.API.Entities;
using ImSuperSir.GameStore.API.Repositories;

namespace ImSuperSir.GameStore.API.EndPoints
{
    public static class GameEndPoints
    {

        const string GetGameEndPointName = "GamesStore";


        public static RouteGroupBuilder MapGameEndPoints(this IEndpointRouteBuilder routes)
        {

            var group = routes.MapGroup("/games").WithParameterValidation();

            group.MapGet("/", async (IGamesRepository repository) =>
            {
                //TODO: check for when the list is empty
                return Results.Ok((await repository.GetAllAsync()).Select(game => game.AsGameDto()));
            });

            group.MapGet("/{id}", async (IGamesRepository repository, int id) =>
            {
                Game? game = await repository.GetAsync(id);
                return game != null ? Results.Ok(game.AsGameDto()) : Results.NotFound();

            }).WithName(GetGameEndPointName)
            .RequireAuthorization(Policies.ReadAccess);

            group.MapPost("/", async (IGamesRepository repository, CreateGameDto gameDto) =>
            {
                Game game = new Game()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    ImageUri = gameDto.ImageUri,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,

                };
                await repository.CreateAsync(game);
                return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);

            })
            .RequireAuthorization(Policies.WriteAcces);

            group.MapPut("/{id}", async (IGamesRepository repository, UpdateGameDto updatedGameDto, int id) =>
            {

                Game? existingGame = await repository.GetAsync(id);

                if (existingGame == null) return Results.NotFound();

                existingGame.Name = updatedGameDto.Name;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.Price = updatedGameDto.Price;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageUri = updatedGameDto.ImageUri;

                await repository.UpdateAsync(existingGame);

                return Results.NoContent();

            })
            .RequireAuthorization(Policies.WriteAcces);

            group.MapDelete("/{id}", async (IGamesRepository repository, int id) =>
            {
                Game? game = await repository.GetAsync(id);

                if (game != null)
                {
                    await repository.DeleteAsync(id);
                }

                return Results.NoContent();

            })
            .RequireAuthorization(Policies.WriteAcces);

            return group;
        }
    }
}


