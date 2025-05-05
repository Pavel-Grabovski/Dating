namespace Dating.Authentication.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddAPIServices(builder.Configuration)
            .AddInfrastructureServices(builder.Configuration);

        var app = builder.Build();



        app.UseAPIServices();
        await app.InitializeDatabaseAsync();

        app.Run();
    }
}
