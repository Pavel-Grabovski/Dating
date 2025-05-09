namespace Dating.Profile.CommandService.Infrastructure.KafkaProducer;

public class EventKafkaProducer(IOptions<ProducerConfig> config)
    : IEventKafkaProducer
{
    public async Task PublishEventAsync<T>(string topic, T eventSource)
        where T : BaseEvent
    {
        using var producer = new ProducerBuilder<string, string>(config.Value)
            .SetKeySerializer(Serializers.Utf8)
            .SetValueSerializer(Serializers.Utf8)
            .Build();

        var message = new Message<string, string>
        {
            Key = Guid.NewGuid().ToString(),
            Value = JsonSerializer.Serialize(eventSource, eventSource.GetType())
        };

        var result = await producer.ProduceAsync(topic, message);

        if (result.Status == PersistenceStatus.NotPersisted)
        {
            string errorText = 
                $"Failed to send {eventSource.GetType().Name} message to topic - {topic} why: {result.Message}";

            throw new Exception(errorText);
        }
    }
}