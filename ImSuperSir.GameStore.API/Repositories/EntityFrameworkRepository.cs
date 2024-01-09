using ImSuperSir.GameStore.API.Data;
using ImSuperSir.GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImSuperSir.GameStore.API.Repositories;

public class EntityFrameworkRepository : IGamesRepository
{

    private readonly GameStoreContext dbContext;

    public EntityFrameworkRepository(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }



    //public EntityFrameworkRepository()
    //{

    //}

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await dbContext.Games.AsNoTracking().ToListAsync();
    }
    public async Task<Game?> GetAsync(int id)
    {
        return await dbContext.Games.FindAsync(id);
    }

    public async Task CreateAsync(Game newGame)
    {
        dbContext.Games.Add(newGame);
        await dbContext.SaveChangesAsync();

        
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        dbContext.Update(updatedGame);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await dbContext.Games.Where(game => game.Id == id)
            .ExecuteDeleteAsync ();
        
        /*This a second wat to delete a record from the database, usint the traditional way*/

        //var gameToDelete = dbContext.Games.Find(id);
        //if(null != gameToDelete)
        //{
        //    dbContext.Games.Remove(gameToDelete);
        //    dbContext.SaveChanges();
        //}
    }


    

    
}
