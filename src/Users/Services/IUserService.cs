using src.Users.DTOs;

namespace src.Users.Services;

public interface IUserService
{
    Task<UserResponseDto> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
