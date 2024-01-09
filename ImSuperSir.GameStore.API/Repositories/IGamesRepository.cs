using ImSuperSir.GameStore.API.Entities;

namespace ImSuperSir.GameStore.API.Repositories
{
    public interface IGamesRepository
    {
        Task CreateAsync(Game newGame);
        Task DeleteAsync(int id);
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game?> GetAsync(int id);
        Task UpdateAsync(Game updatedGame);
    }
}