namespace Dating.Shared.Exceptions;

public class AggregateNotFoundException : Exception
{
    public AggregateNotFoundException(
        string message = nameof(AggregateNotFoundException)
    ) : base(message) { }
}