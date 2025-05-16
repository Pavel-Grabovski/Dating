namespace Dating.Profile.CommandService.Infrastructure.Services;

public class EventService(
    IEventStorage eventStorage,
    IEventKafkaProducer eventKafkaProducer, 
    IConfiguration configuration) : IEventService
{
    public async Task SaveEventsAsync(BaseEvent baseEvent, CancellationToken ct)
    {
        var eventModel = new EventModel(
            Id: Guid.NewGuid().ToString(),
            CreatedAt: DateTime.UtcNow,
            EventType: nameof(baseEvent),
            EventData: baseEvent);

        await eventStorage.SaveAsync(eventModel, ct);


        var topic = configuration.GetValue<string>("Kafka:Topic")!; 
        await eventKafkaProducer.PublishEventAsync(topic, baseEvent);
    }
}
