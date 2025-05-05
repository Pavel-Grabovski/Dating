
namespace Dating.Authentication.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddAPIServices(builder.Configuration)
            .AddInfrastructureServices(builder.Configuration);

        var app = builder.Build();



        app.UseAPIServices();
        app.Run();
    }
}
