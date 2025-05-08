using Dating.Profile.Domain.Enum;

namespace Dating.Profile.Domain.Entities;

public class UserProfile
{
    public Guid Id { get; set; }

    public required string Name { get; set; }
    
    public Gender Gender { get; set; }

    public DateOnly Birthday { get; set; }

    public bool HaveChildren { get; set; }

    public required Point Location { get; set; }

    public DateTime WasOnline { get; set; }

    public bool IsDelete { get; set; }
    public DateTime? DeletionTime { get; set; }

    public UserSearchFilters Preferences { get; set; } = default!;

    public PremiumSubscription PremiumSubscription { get; set; } = default!;
}