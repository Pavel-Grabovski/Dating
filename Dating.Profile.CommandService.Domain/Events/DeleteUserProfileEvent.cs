namespace Dating.Profile.Application.Events;

public class DeleteUserProfileEvent : BaseEvent
{
    public Guid UserId { get; set; }

    public DeleteUserProfileEvent() : base(nameof(DeleteUserProfileEvent))
    {
    }
}