namespace Dating.Profile.Core.Events.UserProfile;

public class DeleteUserProfileEvent : BaseEvent
{
    public required Guid UserId { get; set; }
    public DateTime DeletionTime { get; set; } = DateTime.UtcNow;

    public DeleteUserProfileEvent() : base(nameof(DeleteUserProfileEvent))
    {
    }
}
