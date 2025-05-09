namespace Dating.Profile.Application.DTOs;

public record CreateUserProfileResponseDTO
(
    string Name,
    GenderDTO Gender,
    DateOnly Birthday,
    bool HaveChildren
);