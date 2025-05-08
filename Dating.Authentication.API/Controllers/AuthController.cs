namespace Dating.Authentication.API.Controllers;

[Route("api/[controller]/[action]")]
public class AuthController : DatingControllerBase
{
    [HttpPost]
    public async Task<IResult> Login(LoginRequestDTO dto, CancellationToken cancellationToken)
    {
        return Results.Ok(await Mediator.Send(new LoginQuery(dto), cancellationToken));
    }

    [HttpPost]
    public async Task<IResult> Register(RegisterUserRequestDTO dto, CancellationToken cancellationToken)
    {
        return Results.Ok(await Mediator.Send(new RegisterCommand(dto), cancellationToken));
    }
}
