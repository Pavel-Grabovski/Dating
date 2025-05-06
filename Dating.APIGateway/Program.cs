using Microsoft.AspNetCore.RateLimiting;
namespace Dating.APIGateway;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddReverseProxy()
            .LoadFromConfig(builder.Configuration.GetSection("YarpProxy"));

        //builder.Services.AddRateLimiter(option =>
        //{
        //    option.AddFixedWindowLimiter("fixed", config =>
        //    {
        //        config.PermitLimit = 3;
        //        config.Window = TimeSpan.FromSeconds(10);
        //    });
        //});

        var app = builder.Build();

        //app.UseRateLimiter();
        //app.MapReverseProxy().RequireRateLimiting("fixed");

        app.MapReverseProxy();

        app.Run();

    }
}
