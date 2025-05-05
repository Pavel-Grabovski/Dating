namespace Dating.Authentication.Application.Services;

public interface IJWTSecurityService
{
    public string CreateToken(User user);
}
