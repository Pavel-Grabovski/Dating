namespace Dating.Profile.Application.Commands.UpdateUserProfile;

public record UpdateUserProfileCommand(UpdateUserProfileRequestDTO CreateUserProfileRequest)
    : ICommand<UpdateUserProfileResult>;