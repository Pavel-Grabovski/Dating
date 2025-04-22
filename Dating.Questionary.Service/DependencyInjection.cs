using Microsoft.AspNetCore.Mvc;

namespace Dating.Questionary.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddAPIServices(
       this IServiceCollection services,
       IConfiguration configuration)
    {

        services.AddControllers();

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
        app.UseHttpsRedirection();

        //app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        return app;
    }
}
