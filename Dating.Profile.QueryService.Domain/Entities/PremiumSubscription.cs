namespace Dating.Profile.Domain.Entities;

public class PremiumSubscription
{
    public Guid UserId { get; set; }

    public bool IsActive { get; set; }

    public DateTime EndTime { get; set; }

    public UserProfile Owner { get; set; } = default!;
}