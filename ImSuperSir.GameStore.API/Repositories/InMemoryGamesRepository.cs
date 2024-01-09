using ImSuperSir.GameStore.API.Entities;

namespace ImSuperSir.GameStore.API.Repositories
{
    public class InMemoryGamesRepository : IGamesRepository
    {

        private List<Game> games = new List<Game>()
            {
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
        public InMemoryGamesRepository() { }

        public async Task<IEnumerable<Game>> GetAllAsync() 
        {  
            return await Task.FromResult( games); 
        }


        public async Task<Game?> GetAsync(int id) 
        { 
            return await Task.FromResult( games.Find(game => game.Id == id)); 
        }
        public async Task CreateAsync(Game newGame) 
        {
            newGame.Id = games.Max(game => game.Id) + 1;
            games.Add(newGame);

            await Task.CompletedTask;

        }

        public async Task UpdateAsync(Game updatedGame)
        {
            var index = games.FindIndex(game => game.Id == updatedGame.Id);
            games[index] = updatedGame;

            await Task.CompletedTask;
        }


        public async Task DeleteAsync(int id) {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);

            await Task.CompletedTask;
        }


    }
}
