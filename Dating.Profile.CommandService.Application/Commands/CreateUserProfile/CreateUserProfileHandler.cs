using Dating.Profile.Application.Services;
using Dating.Shared.Domain.Events;

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
        };

        await eventService.SaveEventsAsync(createUserProfileEvent, cancellationToken);

        return new CreateUserProfileResult(true);
    }
}


public class CreateUserProfileEvent : BaseEvent
{
    public CreateUserProfileEvent() : base(nameof(CreateUserProfileEvent))
    {
    }

    public Guid UserId { get; set; }
}