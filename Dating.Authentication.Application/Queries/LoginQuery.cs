using Dating.Shared.Application.SQRS;

namespace Dating.Authentication.Application.Queries;

public record LoginQuery(LoginRequestDTO LoginRequest)
    : IQuery<LoginResult>;
