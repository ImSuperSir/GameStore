using Microsoft.Extensions.Options;

namespace ImSuperSir.GameStore.API.CORS;

public static class CorsExtensions
{

    private const string AllowedOriginSetting = "AllowedOrigin";

    public static IServiceCollection AddGameStoreCors(this IServiceCollection services
        , IConfiguration configuration)
    {
        return services.AddCors(options => {
            options.AddDefaultPolicy(corsBuilder =>
            {
                var allowedOrigin = configuration[AllowedOriginSetting] ??
                    throw new InvalidOperationException("AllowedOrigin is not set");
                corsBuilder.WithOrigins(allowedOrigin)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}
