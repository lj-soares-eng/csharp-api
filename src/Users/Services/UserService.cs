using Microsoft.EntityFrameworkCore;
using src.Users.Data;
using src.Users.DTOs;
using src.Users.Entities;

namespace src.Users.Services;

public sealed class UserService : IUserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<UserResponseDto> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
    {
        var email = dto.Email.Trim().ToLowerInvariant();

        if (await _db.Users.AnyAsync(u => u.Email == email, cancellationToken))
            throw new DuplicateEmailException(email);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = dto.Name.Trim(),
            Email = email,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = "user",
            CreatedAt = DateTime.UtcNow
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync(cancellationToken);

        return Map(user);
    }

    public async Task<IReadOnlyList<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _db.Users
            .AsNoTracking()
            .OrderBy(u => u.CreatedAt)
            .Select(u => new UserResponseDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role,
                CreatedAt = u.CreatedAt
            })
            .ToListAsync(cancellationToken);
    }

    private static UserResponseDto Map(User u) => new()
    {
        Id = u.Id,
        Name = u.Name,
        Email = u.Email,
        Role = u.Role,
        CreatedAt = u.CreatedAt
    };
}

public sealed class DuplicateEmailException : Exception
{
    public DuplicateEmailException(string email)
        : base($"Email already registered: {email}")
    {
    }
}
