namespace Dating.Profile.Application.Commands.DeleteUserProfile;

public class DeleteUserProfileHandler(
    IUserAccessor userAccessor,
    IEventService eventService)
    : ICommandHandler<DeleteUserProfileCommand, DeleteUserProfileResult>
{
    public async Task<DeleteUserProfileResult> Handle(
        DeleteUserProfileCommand request,
        CancellationToken cancellationToken)
    {
        string userId = userAccessor.GetUserId();

        DeleteUserProfileEvent deleteUserProfileEvent = new()
        {
            UserId = Guid.Parse(userId)
        };

        await eventService.SaveEventsAsync(deleteUserProfileEvent, cancellationToken);

        return new DeleteUserProfileResult(true);
    }
}