using ImSuperSir.GameStore.API.Entities;

namespace ImSuperSir.GameStore.API.Repositories
{
    public interface IGamesRepository
    {
        void Create(Game newGame);
        void Delete(int id);
        List<Game> GetAll();
        Game? GetGameById(int id);
        void Update(Game updatedGame);
    }
}