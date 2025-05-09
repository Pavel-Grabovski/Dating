namespace Dating.Shared.Domain.Events;

public abstract class BaseEvent : Message
{
    public string EventType { get; set; }
    protected BaseEvent(string eventType)
    {
        EventType = eventType;
    }
}