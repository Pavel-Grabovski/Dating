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

    public static IServiceCollection AddCommandServices(
        this IServiceCollection services, IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("PgConnection")!;
        services
            .AddMarten(opt => opt.Connection(connectionString))
            .UseLightweightSessions();

        services.AddExceptionHandler<ExtensionHandler>();


        services.AddControllers(options =>
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            options.Filters.Add(new AuthorizeFilter(policy));
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddOpenApi();

        return services;
    }

    public static WebApplication UseAPIServices
    (this WebApplication app)
    {

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseExceptionHandler(options => { });
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}
