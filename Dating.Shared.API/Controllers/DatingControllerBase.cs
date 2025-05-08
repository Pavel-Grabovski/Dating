namespace Dating.Shared.API.Controllers;

[ApiController]
public class DatingControllerBase : ControllerBase
{
    private IMediator _mediator = default!;
    protected IMediator Mediator => _mediator ??=
        HttpContext!.RequestServices.GetService<IMediator>()!;
}