namespace Dating.Shared.Event;

public abstract class BaseEvent : Message
{
    public string EventType { get; set; }
    public int Version { get; set; }
    protected BaseEvent(string eventType)
    {
        EventType = eventType;
    }
}