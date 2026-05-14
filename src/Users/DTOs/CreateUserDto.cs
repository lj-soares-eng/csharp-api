using System.ComponentModel.DataAnnotations;

namespace src.Users.DTOs;

public class CreateUserDto
{
    public Guid? Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(40)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    [MaxLength(128)]
    public string Password { get; set; } = string.Empty;

    [MaxLength(10)]
    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; }
}
