namespace Dating.Authentication.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString(
            "PostgreSQLConnection");

        services.AddDbContext<IAuthenticationDbContext, AuthenticationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddHttpContextAccessor();
        services.AddIdentityServices(configuration);
        services.AddScoped<IUserAccessor, UserAccessor>();
        return services;
    }
}