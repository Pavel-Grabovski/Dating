namespace Dating.Authentication.API.Controllers;

[Route("api/[controller]")]
public class AuthController : DatingControllerBase
{
    [HttpPost("login")]
    public async Task<IResult> Login(LoginRequestDTO dto, CancellationToken cancellationToken)
    {
        return Results.Ok(await Mediator.Send(new LoginQuery(dto), cancellationToken));
    }

    [HttpPost("register")]
    public async Task<IResult> Register(RegisterUserRequestDTO dto, CancellationToken cancellationToken)
    {
        return Results.Ok(await Mediator.Send(new RegisterCommand(dto), cancellationToken));
    }
}
