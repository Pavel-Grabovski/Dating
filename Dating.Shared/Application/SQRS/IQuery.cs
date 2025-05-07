namespace Dating.Shared.Application.SQRS;

public interface IQuery<out TResponse>
    : IRequest<TResponse>
{

}