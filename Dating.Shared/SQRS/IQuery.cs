﻿namespace Dating.Shared.SQRS;

public interface IQuery<out TResponse>
    : IRequest<TResponse>
{

}