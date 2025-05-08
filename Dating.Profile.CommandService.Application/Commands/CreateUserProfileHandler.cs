namespace Dating.Profile.CommandService.Application.Commands;

public class CreateUserProfileHandler() 
    : ICommandHandler<CreateUserProfileCommand, CreateUserProfileResult>
{
    public Task<CreateUserProfileResult> Handle(
        CreateUserProfileCommand request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
