namespace Dating.Authentication.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddLogger();

        builder.Services
            .AddAPIServices(builder.Configuration)
            .AddInfrastructureServices(builder.Configuration);

        var app = builder.Build();


        app.UseSerilogRequestLogging();
        app.UseAPIServices();
        await app.InitializeDatabaseAsync();

        app.Run();
    }
}
