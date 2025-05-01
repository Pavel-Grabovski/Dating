namespace Dating.Profile.QueryService.Domain.Entities;

public class UserProfile
{
    public Guid Id { get; set; }

    public required string Name { get; set; }
    
    public Gender Gender { get; set; }

    public DateOnly Birthday { get; set; }

    public bool HaveChildren { get; set; }

    public required Point Location { get; set; }

    public DateTime WasOnline { get; set; }

    public UserPreferences Preferences { get; set; } = default!;

    public PremiumSubscription PremiumSubscription { get; set; } = default!;
}