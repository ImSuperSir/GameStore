using ImSuperSir.GameStore.API.DTOs;

namespace ImSuperSir.GameStore.API.Entities
{
    public static class EntityExtensions
    {

        public static GameDtov1 AsGameDtoV1(this Game game)
        {
            return new GameDtov1(
                game.Id,
                game.Name,
                game.Genre,
                game.Price,
                game.ReleaseDate,
                game.ImageUri
                );
        }

        public static GameDtov2 AsGameDtoV2(this Game game)
        {
            return new GameDtov2(
                game.Id,
                game.Name,
                game.Genre,
                game.Price - (game.Price * .3m),
                game.Price,
                game.ReleaseDate,
                game.ImageUri
                );
        }

    }
}
