using Dating.Shared.Aggregates;

namespace Dating.Shared.Handlers;
public interface IEventHandler<T>
{
    public Task<T> GetAggregateByIdAsync(Guid Id, CancellationToken ct);
    public Task SaveAsync(BaseAggregate item, CancellationToken ct);
}
