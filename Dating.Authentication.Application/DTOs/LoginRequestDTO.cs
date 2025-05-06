namespace Dating.Authentication.Application.DTOs;

public record LoginRequestDTO
(
    string Login,
    string Password
);