using System.ComponentModel.DataAnnotations;

namespace src.Users.DTOs;

public class UpdateUserDto
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(40)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string Role { get; set; } = string.Empty;

    [MaxLength(128)]
    public string? Password { get; set; }
}
