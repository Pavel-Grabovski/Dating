namespace Dating.Profile.CommandService.Infrastructure.DAO;

public interface IEventStorage
{
    public Task SaveAsync(EventModel eventModel, CancellationToken ct);
}
