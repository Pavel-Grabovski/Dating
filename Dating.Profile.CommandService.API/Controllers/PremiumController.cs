namespace Dating.Profile.CommandService.API.Controllers;

public class PremiumController : ProfileControllerBase
{
    [HttpPost]
    public async Task<IResult> Active()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IResult> Prolong()
    {
        throw new NotImplementedException();
    }

    [Obsolete]
    [HttpPost]
    public async Task<IResult> Deactive()
    {
        throw new NotImplementedException();
    }
}