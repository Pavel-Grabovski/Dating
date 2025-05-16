namespace Dating.Profile.Application.Commands.CreateUserProfile;

public class CreateUserProfileHandler(
    IUserAccessor userAccessor,
    IEventService eventService) 
    : ICommandHandler<CreateUserProfileCommand, CreateUserProfileResult>
{
    public async Task<CreateUserProfileResult> Handle(
        CreateUserProfileCommand request, 
        CancellationToken cancellationToken)
    {
        string userId = userAccessor.GetUserId();

        CreateUserProfileEvent createUserProfileEvent = new()
        {
            UserId = Guid.Parse(userId),
            Name = request.CreateUserProfileRequest.Name,
            Gender = (Gender)(int)request.CreateUserProfileRequest.Gender,
            Birthday = request.CreateUserProfileRequest.Birthday,
            HaveChildren = request.CreateUserProfileRequest.HaveChildren
        };

        await eventService.SaveEventsAsync(createUserProfileEvent, cancellationToken);

        return new CreateUserProfileResult();
    }
}
