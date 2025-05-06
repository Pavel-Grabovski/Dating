namespace Dating.Authentication.Application.DTOs;

public record UserResponseDTO
(
    string UserName,
    string Email,
    string JwtToken
);
