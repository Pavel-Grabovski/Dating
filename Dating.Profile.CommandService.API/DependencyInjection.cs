namespace Dating.Profile.CommandService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddCommandServices(
        this IServiceCollection services, IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("PgConnection")!;
        services
            .AddMarten(opt => opt.Connection(connectionString))
            .UseLightweightSessions();

        services.AddScoped<IEventStorage, EventStorage>();
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }
}
