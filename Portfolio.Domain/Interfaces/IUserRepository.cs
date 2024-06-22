using Portfolio.Core.Models;

public interface IUserRepository
{

    User GetUserById(int userId);
    IEnumerable<User> GetUsers();


    Task<User> GetUserByIdAsync(int userId);
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserByUsernameAsync(string username);
    Task<IEnumerable<User>> GetAllUsersAsync();


    Task RegisterUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int userId);
}
