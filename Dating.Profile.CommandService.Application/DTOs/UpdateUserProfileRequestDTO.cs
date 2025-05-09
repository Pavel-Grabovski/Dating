namespace Dating.Profile.Application.DTOs;

public record UpdateUserProfileRequestDTO
(
    string Name,
    GenderDTO Gender,
    DateOnly Birthday,
    bool HaveChildren,
    PointDTO? Location
);
