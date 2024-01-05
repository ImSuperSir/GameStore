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

            group.MapGet("/", (IGamesRepository repository) =>
            {
                //TODO: check for when the list is empty
                return Results.Ok(repository.GetAll().Select( game => game.AsGameDto()));
            });

            group.MapGet("/{id}", (IGamesRepository repository, int id) =>
            {
                Game? game = repository.GetGameById(id);
                return game != null ? Results.Ok(game.AsGameDto()) : Results.NotFound();

            }).WithName(GetGameEndPointName);

            group.MapPost("/", (IGamesRepository repository,CreateGameDto gameDto) =>
            {
                Game game = new Game() 
                { 
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    ImageUri = gameDto.ImageUri,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                   
                };
                repository.Create(game);
                return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);

            });

            group.MapPut("/{id}", (IGamesRepository repository,UpdateGameDto updatedGameDto, int id) =>
            {

                Game? existingGame = repository.GetGameById(id);

                if (existingGame == null) return Results.NotFound();

                existingGame.Name = updatedGameDto.Name;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.Price = updatedGameDto.Price;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageUri = updatedGameDto.ImageUri;

                repository.Update(existingGame);

                return Results.NoContent();

            });

            group.MapDelete("/{id}", (IGamesRepository repository,int id) =>
            {
                Game? game = repository.GetGameById(id); 

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


