namespace Dating.Profile.Application.Commands.CreateUserProfile;

public class CreateUserProfileHandler(
    IUserAccessor userAccessor) 
    : ICommandHandler<CreateUserProfileCommand, CreateUserProfileResult>
{
    public Task<CreateUserProfileResult> Handle(
        CreateUserProfileCommand request, 
        CancellationToken cancellationToken)
    {
        string userId = userAccessor.GetUserId();
        throw new NotImplementedException();
    }
}
