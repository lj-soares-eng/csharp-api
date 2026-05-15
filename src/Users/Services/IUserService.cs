using src.Users.DTOs;

namespace src.Users.Services;

public interface IUserService
{
    Task<UserResponseDto> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<UserResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<UserResponseDto?> UpdateAsync(int id, UpdateUserDto dto, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
