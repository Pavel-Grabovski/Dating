namespace Dating.Profile.Core.Events.UserProfile;

public class UpdateUserProfileEvent : BaseEvent
{
    public required Guid UserId { get; set; }

    public required string Name { get; set; }

    public required Gender Gender { get; set; }

    public required DateOnly Birthday { get; set; }

    public required bool HaveChildren { get; set; }

    public required Point Location { get; set; }

    public DateTime WasOnline { get; set; } = DateTime.UtcNow;


    public UpdateUserProfileEvent() : base(nameof(UpdateUserProfileEvent))
    {
    }
}