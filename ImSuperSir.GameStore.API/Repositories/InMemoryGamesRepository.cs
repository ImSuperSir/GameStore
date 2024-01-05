using ImSuperSir.GameStore.API.Entities;

namespace ImSuperSir.GameStore.API.Repositories
{
    public class InMemoryGamesRepository
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

        public List<Game> GetAll() {  return games; }


        public Game? GetGameById(int id) 
        { 
            return games.Find(game => game.Id == id); 
        }
        public void Create(Game newGame) 
        {
            newGame.Id = games.Max(game => game.Id) + 1;
            games.Add(newGame);
        }

        public void Update(Game updatedGame)
        {
            var index = games.FindIndex(game => game.Id == updatedGame.Id);
            games[index] = updatedGame;
        }


        public void Delete(int id) {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);
        }


    }
}
