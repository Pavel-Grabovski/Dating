namespace Dating.Profile.Core.Events;

public class ActivePremiumSubscriptionEvent : BaseEvent
{
    public required Guid UserId { get; set; }

    public required TimeSpan Time { get; set; }

    public ActivePremiumSubscriptionEvent() : base(nameof(ActivePremiumSubscriptionEvent))
    {
    }
}
