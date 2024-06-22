using Portfolio.Core.Exceptions;
using Portfolio.Core.Models;
using Portfolio.Domain.Interfaces;

namespace Portfolio.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }



        public async Task<bool> Login(string username, string password)
        {
            try
            {
                var user = await _userRepository.GetUserByUsernameAsync(username);

                if (user == null)
                {
                    return false;
                }

                return _passwordHasher.VerifyPassword(user.PasswordHash, password);
            }
            catch (Exception ex)
            {

                throw new UserAuthenticationException("An error occurred during login.", ex);
            }
        }


        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<string> GetStoredPasswordHash(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null)
            {
                throw new UserNotFoundException($"User with username '{username}' not found.");
            }

            return user.PasswordHash;
        }

    }
}
