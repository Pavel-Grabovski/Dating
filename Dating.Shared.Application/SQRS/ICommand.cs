namespace Dating.Shared.Application.SQRS;

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}

public interface ICommand : IRequest<Unit>
{

}