namespace ImSuperSir.GameStore.API.Authorization;

public static class Extensions
{

    public static IServiceCollection AddGameStoreAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options => 
        {
            options.AddPolicy(Policies.ReadAccess, builder =>
            {
                builder.RequireClaim("scope", "games:read");
            });

            options.AddPolicy(Policies.WriteAcces, builder =>
            {
                builder.RequireClaim("scope", "games:write")
                        .RequireRole("Admin");
            });

        }
        );

        return services;

    }
}
