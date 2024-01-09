using ImSuperSir.GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ImSuperSir.GameStore.API.Data;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Game> Games => Set<Game>();



}
