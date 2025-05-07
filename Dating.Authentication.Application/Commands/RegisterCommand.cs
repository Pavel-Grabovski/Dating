using Dating.Shared.Application.SQRS;

namespace Dating.Authentication.Application.Commands;

public record RegisterCommand(RegisterUserRequestDTO Dto)
    : ICommand<RegisterResult>;
