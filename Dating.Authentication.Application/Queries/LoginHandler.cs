namespace Dating.Authentication.Application.Queries;

public class LoginHandler(
    UserManager<User> userManager,
    IJWTSecurityService jwtSecurityService)
    : IQueryHandler<LoginQuery, LoginResult>
{
    public async Task<LoginResult> Handle(
        LoginQuery request,
        CancellationToken cancellationToken)
    {
        User? user = await userManager.Users
            .FirstOrDefaultAsync(
              u => request.LoginRequest.Login.ToUpper() == u.NormalizedEmail
                || request.LoginRequest.Login.ToUpper() == u.NormalizedUserName,
              cancellationToken);

        if (user == null)
            throw new UnauthorizedException();

        bool result = await userManager
            .CheckPasswordAsync(user, request.LoginRequest.Password);

        if (!result)
            throw new UnauthorizedException();

        UserResponseDTO response = new(
                user.UserName,
                user.Email,
                jwtSecurityService.CreateToken(user));

        return new LoginResult(response);

    }
}