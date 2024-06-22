using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Models;

public class UserRepository : IUserRepository
{
    private readonly Portfolio.Infrastructure.PortfolioDbContext _context;

    public UserRepository(Portfolio.Infrastructure.PortfolioDbContext context)
    {
        _context = context;
    }


    public User GetUserById(int userId)
    {
        return _context.Users.Find(userId);
    }

    public IEnumerable<User> GetUsers()
    {
        return _context.Users.ToList();
    }


    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task<User> GetUserByUsernameAsync(string username)
    {

        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }




    public async Task RegisterUserAsync(User user)
    {
  
        user.PasswordHash = HashPassword(user.PasswordHash);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null)
        {
           
            // user.IsDeleted = true;
            // await _context.SaveChangesAsync();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }


    private string HashPassword(string password)
    {
        return "HashedPassword";
    }
}
