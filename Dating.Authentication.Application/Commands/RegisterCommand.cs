namespace Dating.Authentication.Application.Commands;

public record RegisterCommand(RegisterUserRequestDTO Dto)
    : ICommand<RegisterResult>;
