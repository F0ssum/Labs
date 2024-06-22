using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Models;
using Portfolio.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public UserController(IUserService userService, IPasswordHasher passwordHasher, IUserRepository userRepository)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<User> Register(RegisterUserDto userDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Password))
                {
                    throw new ArgumentException("Username and password cannot be empty or whitespace.");
                }

                var hashedPassword = _passwordHasher.HashPassword(userDto.Password);

                var user = new User
                {
                    Username = userDto.Username,
                    Email = userDto.Email,
                    PasswordHash = hashedPassword,
                    UserId = Guid.NewGuid().GetHashCode()
                };

                await _userRepository.RegisterUserAsync(user);
                return user;
            }
            catch (ArgumentException ex)
            {
                // Обработка исключения
                // ...
                throw;
            }
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string storedHash = await _userService.GetStoredPasswordHash(loginDto.Username);

                bool isValidPassword = _passwordHasher.VerifyPassword(loginDto.Password, storedHash);

                if (isValidPassword)
                {
                    // ... успешный вход
                    return Ok(); 
                }
                else
                {
                    // ... ошибочный вход
                    return Unauthorized(); 
                }
            }
            catch (Exception ex)
            {
                // ... обработка ошибки
                return BadRequest(ex.Message); 
            }
        }

        public class RegisterUserDto
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public class UserLoginDto
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }
        }
    }
}
