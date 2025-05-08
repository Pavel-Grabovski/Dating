namespace Dating.Profile.CommandService.API.Controllers;

public class UserController : ProfileControllerBase
{
    [HttpPost]
    public async Task<IResult> Create()
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public async Task<IResult> Update()
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public async Task<IResult> Delete(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}