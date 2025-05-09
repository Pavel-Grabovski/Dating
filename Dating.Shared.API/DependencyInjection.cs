namespace Dating.Shared.API;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedAPIServices(
       this IServiceCollection services, IConfiguration configuration)
    {
        services.AddExceptionHandler<ExtensionHandler>();

        string secretKey = configuration["AuthSettings:SecretKey"]!;
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(secretKey));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                };
            });

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

        services.AddHttpContextAccessor();
        services.AddScoped<IUserAccessor, UserAccessor>();

        return services;
    }


    public static WebApplication UseSharedAPIServices
        (this WebApplication app)
    {

        if (app.Environment.IsDevelopment())
        {
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
