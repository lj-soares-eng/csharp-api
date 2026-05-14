using System.ComponentModel.DataAnnotations.Schema;

namespace src.Users.Entities;

[Table("users")]
public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    /// <summary>BCrypt password hash — never store plain text.</summary>
    public string Password { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
