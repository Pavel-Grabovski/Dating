namespace Dating.Shared.Events.DAO;

public interface IEventStorage
{
    public Task SaveAsync(EventModel eventModel, CancellationToken ct);
    public Task<IEnumerable<EventModel>> FindByAggregateId(Guid id, CancellationToken ct);
}
