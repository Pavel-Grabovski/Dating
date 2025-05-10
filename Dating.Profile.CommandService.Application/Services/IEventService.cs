using Dating.Shared.Domain.Events;

namespace Dating.Profile.Application.Services;

public interface IEventService
{
    public Task SaveEventsAsync(BaseEvent baseEvent,CancellationToken ct);
}