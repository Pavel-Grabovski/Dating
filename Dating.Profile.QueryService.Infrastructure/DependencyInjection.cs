namespace Dating.Profile.QueryService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString(
            "PostgreSQLConnection");

        services.AddDbContext<ApplicationDBContext>(options =>
        {
            options.UseNpgsql(connectionString, o =>
            {
                
                o.MapEnum<Gender>("gender");
                o.UseNetTopologySuite();
            });

        });
        return services;
    }
}
