using Dating.Profile.Application.Commands.DeleteUserProfile;

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
    public async Task<IResult> Update(
        [FromBody] UpdateUserProfileRequestDTO dto,
        CancellationToken cancellationToken)
    {
        return Results.Ok(await Mediator.Send(new UpdateUserProfileCommand(dto), cancellationToken));
    }

    [HttpDelete]
    public async Task<IResult> Delete(CancellationToken cancellationToken)
    {

        return Results.Ok(await Mediator.Send(new DeleteUserProfileCommand(), cancellationToken));
    }
}