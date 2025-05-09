namespace Dating.Shared.Domain.Events;

public record EventModel(
    string Id,
    DateTime CreatedAt,
    string EventType,
    BaseEvent EventData
);