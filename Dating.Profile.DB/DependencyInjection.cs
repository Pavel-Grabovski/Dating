using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Dating.Profile.DB;
public static class DependencyInjection
{
    public static IServiceCollection AddDataBaseServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString(
            "PostgreSQLConnection");

        return services;
    }
}