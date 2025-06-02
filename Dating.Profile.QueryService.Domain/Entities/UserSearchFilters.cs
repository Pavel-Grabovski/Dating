namespace Dating.Profile.Domain.Entities;

public class UserSearchFilters
{
    public Guid UserId { get; set; }

    public Gender Gender { get; set; }

    public int YearBirthFrom { get; set; }

    public int YearBirthTo { get; set; }

    public int SearchRadius { get; set; }

    public bool? HaveChildren { get; set; }

    public UserProfile UserProfile { get; set; } = default!;
}