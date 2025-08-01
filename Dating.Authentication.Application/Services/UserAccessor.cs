﻿namespace Dating.Authentication.Application.Services;

public class UserAccessor(IHttpContextAccessor httpContextAccessor)
    : IUserAccessor
{
    public string GetUserId()
    {
        return httpContextAccessor
            .HttpContext!
            .User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }
}