namespace Dating.Profile.Core.Events.PremiumSubscription;

public class ProlongPremiumSubscriptionEvent : BaseEvent
{
    public required Guid UserId { get; set; }

    public required TimeSpan Time { get; set; }

    public ProlongPremiumSubscriptionEvent() : base(nameof(ProlongPremiumSubscriptionEvent))
    {
    }
}
