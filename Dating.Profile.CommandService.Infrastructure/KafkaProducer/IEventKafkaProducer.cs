namespace Dating.Profile.CommandService.Infrastructure.KafkaProducer;

public interface IEventKafkaProducer
{
    public Task PublishEventAsync<T>(string topic, T eventSource)
        where T : BaseEvent;
}
