namespace Dating.CommandService.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddLogger();
        builder.Services.AddCommandServices(builder.Configuration);

        var app = builder.Build();

        app.UseSerilogRequestLogging();
        app.UseAPIServices();

        app.Run();
    }
}
