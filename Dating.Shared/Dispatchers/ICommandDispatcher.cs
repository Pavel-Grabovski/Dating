namespace Dating.Shared.Dispatchers;
public interface ICommandDispatcher
{
    public void RegisterHandler<T>(Func<T, Task> handler)
        where T : BaseCommand;
    public Task SendCommandAsync(BaseCommand command);
}