using ImSuperSir.GameStore.API.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Runtime.CompilerServices;

namespace ImSuperSir.GameStore.API.Data;

public static class DataExtensions
{

    /// <summary>
    /// To update automatically our database en sql server
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static async Task InitializaDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();  //since C# 8.0, we do no need the curly brackets, it is disposed and the end of its own scope, in thie case : the method scope
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();

        var logger = serviceProvider.GetRequiredService<ILoggerFactory>()
            .CreateLogger("Db Initializer MyOwnCategory...");
        logger.LogInformation("The Database is Ready");

    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("GamesStoreContext");

        services.AddSqlServer<GameStoreContext>(connString);
        services.AddScoped<IGamesRepository, EntityFrameworkRepository>();

        return services;
        
    }
}
