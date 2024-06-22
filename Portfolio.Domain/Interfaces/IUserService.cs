using Portfolio.Core.Models;

namespace Portfolio.Domain.Interfaces
{
    public interface IUserService
    {

        Task<bool> Login(string username, string password);
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByUsernameAsync(string username);
        Task<string> GetStoredPasswordHash(string username);
    }
}
