namespace Dating.Profile.CommandService.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddLogger();
        builder.Services
            .AddCommandAPIServices()
            .AddSharedAPIServices(builder.Configuration)
            .AddCommandInfrastructureServices(builder.Configuration);

        var app = builder.Build();

        app.UseSerilogRequestLogging();
        app.UseSharedAPIServices();

        app.Run();
    }
}
