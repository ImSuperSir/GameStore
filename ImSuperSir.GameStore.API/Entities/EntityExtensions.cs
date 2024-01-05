using ImSuperSir.GameStore.API.DTOs;

namespace ImSuperSir.GameStore.API.Entities
{
    public static class EntityExtensions
    {

        public static GameDto AsGameDto(this Game game)
        {
            return new GameDto(
                game.Id,
                game.Name,
                game.Genre,
                game.Price,
                game.ReleaseDate,
                game.ImageUri
                );
        }
    }
}
