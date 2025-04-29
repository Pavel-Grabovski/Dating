namespace Dating.Profile.QueryService.Infrastructure.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();

        ApplicationDBContext dbContext = scope.ServiceProvider
            .GetRequiredService<ApplicationDBContext>();


        await dbContext.Database
            .MigrateAsync();
    }
}
