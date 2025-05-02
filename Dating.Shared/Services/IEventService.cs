namespace Dating.Shared.Services;
 
public interface IEventService
{
    public Task<IEnumerable<BaseEvent>> GetEventsAsync(
        Guid aggregateId,
        CancellationToken ct
    );

    public Task SaveEventsAsync(
        Guid aggregateId,
        IEnumerable<BaseEvent> events,
        int expectedVersion,
        CancellationToken ct
    );
}