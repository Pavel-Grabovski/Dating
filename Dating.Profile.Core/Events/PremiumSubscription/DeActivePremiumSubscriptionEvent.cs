namespace Dating.Profile.Core.Events.PremiumSubscription;

public class DeActivePremiumSubscriptionEvent : BaseEvent
{
    public required Guid UserId { get; set; }

    public DeActivePremiumSubscriptionEvent() : base(nameof(DeActivePremiumSubscriptionEvent))
    {
    }
}
