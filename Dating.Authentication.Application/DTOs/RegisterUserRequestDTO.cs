namespace Dating.Authentication.Application.DTOs;

public record RegisterUserRequestDTO
(
    string UserName,
    string Email,
    string Password
);