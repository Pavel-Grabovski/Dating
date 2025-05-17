namespace Dating.Profile.Application.Commands.UpdateUserProfile;

public class UpdateUserProfileHandler(
    IUserAccessor userAccessor,
    IEventService eventService)
    : ICommandHandler<UpdateUserProfileCommand, UpdateUserProfileResult>
{
    public async Task<UpdateUserProfileResult> Handle(
        UpdateUserProfileCommand request,
        CancellationToken cancellationToken)
    {
        string userId = userAccessor.GetUserId();

        UpdateUserProfileEvent updateUserProfileEvent = new()
        {
            UserId = Guid.Parse(userId),
            Name = request.CreateUserProfileRequest.Name,
            Gender = (Gender)(int)request.CreateUserProfileRequest.Gender,
            Birthday = request.CreateUserProfileRequest.Birthday,
            HaveChildren = request.CreateUserProfileRequest.HaveChildren
        };

        await eventService.SaveEventsAsync(updateUserProfileEvent, cancellationToken);

        return new UpdateUserProfileResult(true);
    }
}

