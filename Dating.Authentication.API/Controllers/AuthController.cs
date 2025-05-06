namespace Dating.Authentication.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private IMediator _mediator = default!;
    protected IMediator Mediator => _mediator ??=
        HttpContext!.RequestServices.GetService<IMediator>()!;


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
