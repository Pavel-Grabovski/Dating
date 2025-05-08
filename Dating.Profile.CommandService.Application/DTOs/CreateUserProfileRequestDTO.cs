namespace Dating.Profile.Application.DTOs;

public record CreateUserProfileRequestDTO
(
    string Name,
    GenderDTO Gender,
    DateOnly Birthday,
    bool HaveChildren,
    PointDTO? Location
);
