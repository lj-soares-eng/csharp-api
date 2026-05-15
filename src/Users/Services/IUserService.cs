using src.Users.DTOs;

namespace src.Users.Services;

public interface IUserService
{
    Task<UserResponseDto> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<UserResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UserResponseDto?> UpdateAsync(Guid id, UpdateUserDto dto, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
