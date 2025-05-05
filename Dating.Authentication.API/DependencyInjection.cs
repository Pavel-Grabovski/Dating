namespace Dating.Authentication.API;

public static class DependencyInjection
{
    public static IServiceCollection AddAPIServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddOpenApi();

        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(typeof(RegisterHandler).Assembly));

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