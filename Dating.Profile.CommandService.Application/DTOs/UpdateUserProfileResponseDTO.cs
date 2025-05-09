namespace Dating.Profile.Application.DTOs;

public record UpdateUserProfileResponseDTO
(
    string Name,
    GenderDTO Gender,
    DateOnly Birthday,
    bool HaveChildren
);