namespace Dating.Profile.Core.Events;

public class UpdateUserProfileEvent : BaseEvent
{
    public required Guid UserId { get; set; }
    public string? Name { get; set; }
    public Gender? Gender { get; set; }

    public DateOnly? Birthday { get; set; }

    public bool? HaveChildren { get; set; }

    public Point? Location { get; set; }

    public DateTime WasOnline { get; set; } = DateTime.UtcNow;

    public UpdateUserProfileEvent() : base(nameof(UpdateUserProfileEvent))
    {
    }
}