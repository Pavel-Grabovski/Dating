namespace Dating.Profile.CommandService.API.Controllers;

public class UserController : ProfileControllerBase
{
    [HttpPost]
    public async Task<IResult> Create(
        [FromBody] CreateUserProfileRequestDTO dto,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(new CreateUserProfileCommand(dto), cancellationToken);
        return Results.Created();
    }

    [HttpPut]
    public async Task<IResult> Update()
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public async Task<IResult> Delete(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}