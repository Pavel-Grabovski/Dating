namespace Dating.Shared.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DatingControllerBase : ControllerBase
{
    private IMediator _mediator = default!;
    protected IMediator Mediator => _mediator ??=
        HttpContext!.RequestServices.GetService<IMediator>()!;
}