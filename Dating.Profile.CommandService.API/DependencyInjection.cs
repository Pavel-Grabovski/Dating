namespace Dating.Profile.CommandService.API;

public static class DependencyInjection
{
    public static void AddLogger(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, loggerConfiguration) =>
        {
            loggerConfiguration.WriteTo.Console();
            loggerConfiguration.ReadFrom.Configuration(context.Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("WEB API NAME", "Dating.Profile.CommandService.API");
        });
    }

    public static IServiceCollection AddCommandAPIServices(
        this IServiceCollection services)
    {
        services.AddMediatR(config =>
           config.RegisterServicesFromAssembly(typeof(CreateUserProfileHandler).Assembly));

        return services;
    }
}
