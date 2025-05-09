using Dating.Profile.CommandService.Infrastructure.DAO;

namespace Dating.Profile.CommandService.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddCommandInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PgConnection")!;
        services
            .AddMarten(opt => opt.Connection(connectionString))
            .UseLightweightSessions();

        services.Configure<ProducerConfig>(configuration.GetSection("KafkaConfig"));
        services.AddScoped<IEventKafkaProducer, EventKafkaProducer>();

        services.AddScoped<IEventStorage, EventStorage>();

        return services;
    }
}
