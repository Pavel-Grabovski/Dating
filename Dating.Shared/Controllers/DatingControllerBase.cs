using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Dating.Shared.Controllers;

[ApiController]
[Route("[controller]")]
public class DatingControllerBase : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??=
        HttpContext!.RequestServices.GetService<IMediator>()!;

}