namespace Dating.Profile.QueryService.Domain.Entities;

public class UserPreferences
{
    public Guid UserId { get; set; }

    public Gender Gender { get; set; }

    public int YearBirthFrom { get; set; }

    public int YearBirthTo { get; set; }

    public int SearchRadius { get; set; }

    public bool HaveChildren { get; set; }

    public UserProfile UserProfile { get; set; } = default!;
}