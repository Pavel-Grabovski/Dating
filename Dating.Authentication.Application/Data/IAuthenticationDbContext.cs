namespace Dating.Authentication.Application.Data;

public interface IAuthenticationDbContext
{
    public DbSet<User> Users { get; set; }
}
