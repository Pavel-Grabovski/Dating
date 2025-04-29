namespace Dating.Profile.QueryService.Domain.Entities;

public class UserProfile
{
    public Guid Id { get; set; }

    public required string Name { get; set; }
    
    public Gender Gender { get; set; }

    public DateOnly Birthday { get; set; }

    public int SearchRadius { get; set; }

    public bool HaveChildren { get; set; }
}
