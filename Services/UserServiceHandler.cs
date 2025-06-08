using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;
//koden skriven i samarbete med ChatGPT
namespace UserService.Services;

public class UserServiceHandler
{
    public readonly UserDbContext _context;

    public UserServiceHandler(UserDbContext context)
    {
        _context = context;
    }
    // TODO: Behövs den för validering i BookingService?? Behåll sålänge, 27/5 
    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    //Lista alla användare(för en eventuell admin)
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
    //Hämta user email
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        user.UserId = Guid.NewGuid();
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
