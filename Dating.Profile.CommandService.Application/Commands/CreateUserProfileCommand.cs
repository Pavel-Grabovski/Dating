namespace Dating.Profile.CommandService.Application.Commands;

public record CreateUserProfileCommand(CreateUserProfileRequestDTO CreateUserProfileRequest)
    : ICommand<CreateUserProfileResult>;