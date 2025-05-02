namespace Dating.Profile.Core.Events.SearchFilters;

public class UpdateSearchFiltersEvent : BaseEvent
{
    public required Guid UserId { get; set; }

    public required Gender Gender { get; set; }

    public int YearBirthFrom { get; set; }

    public int YearBirthTo { get; set; }

    public int SearchRadius { get; set; }

    public bool? HaveChildren { get; set; }

    public UpdateSearchFiltersEvent() : base(nameof(UpdateSearchFiltersEvent))
    {
    }
}