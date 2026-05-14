using Microsoft.EntityFrameworkCore;
using src.Users.Entities;

namespace src.Users.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> option)
    : base(option)
    {
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(20).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(40).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Password).HasMaxLength(60).IsRequired();
            entity.Property(e => e.Role).HasMaxLength(10).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });
    }
}