namespace Dating.Authentication.Infrastructure.Data;

public class AuthenticationDbContext : IdentityDbContext<User>, IAuthenticationDbContext
{
    public AuthenticationDbContext(DbContextOptions options) 
        : base(options)
    {
    }
}
