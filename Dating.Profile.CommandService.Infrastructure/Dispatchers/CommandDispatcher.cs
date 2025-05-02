namespace Dating.Profile.CommandService.Infrastructure.Dispatchers;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly Dictionary<Type, Func<BaseCommand, Task>> handlers = new();

    public void RegisterHandler<T>(Func<T, Task> handler)
        where T : BaseCommand
    {
        if (handlers.ContainsKey(typeof(T)))
        {
            throw new InvalidOperationException(
                "Attempting to re-register command handler!"
            );
        }
        handlers.Add(typeof(T), item => handler((T)item));
    }

    public async Task SendCommandAsync(BaseCommand command)
    {
        if (handlers.TryGetValue(command.GetType(),
            out Func<BaseCommand, Task>? handler))
        {
            await handler(command);
        }
        else
        {
            throw new InvalidOperationException(
                "The command handler was not registered!"
            );
        }
    }
}