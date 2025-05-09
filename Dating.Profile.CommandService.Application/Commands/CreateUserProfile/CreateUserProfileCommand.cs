namespace Dating.Profile.Application.Commands.CreateUserProfile;

public record CreateUserProfileCommand(CreateUserProfileRequestDTO CreateUserProfileRequest)
    : ICommand<CreateUserProfileResult>;