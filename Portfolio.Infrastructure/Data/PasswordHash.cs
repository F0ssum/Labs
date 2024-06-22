using Portfolio.Domain.Interfaces;


namespace Portfolio.Infrastructure.Data
{
    using BCrypt = BCrypt.Net.BCrypt;

    public class PasswordHash : IPasswordHasher
    {
        public string HashPassword(string password)
        {

            return BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string storedHash)
        {
 
            return BCrypt.Verify(storedHash, password);
        }
    }
}
