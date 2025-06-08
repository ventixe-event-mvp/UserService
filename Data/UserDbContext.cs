using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data;
//koden skriven i samarbete med ChatGPT
public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; } = null!;
}
