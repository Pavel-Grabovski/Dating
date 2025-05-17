namespace Dating.Profile.Application.Events;

public class UpdateUserProfileEvent : BaseEvent
{
    public Guid UserId { get; set; }

    public required string Name { get; set; }

    public required Gender Gender { get; set; }

    public required DateOnly Birthday { get; set; }

    public required bool HaveChildren { get; set; }

    public UpdateUserProfileEvent() : base(nameof(UpdateUserProfileEvent))
    {
    }

}