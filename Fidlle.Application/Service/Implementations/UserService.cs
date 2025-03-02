using Fidlle.Application.DTO;
using Fidlle.Application.IRepositories;
using Fidlle.Application.Service.Interfaces;
using Fidlle.Domain.Entities;
using System.Security.Cryptography;

namespace Fidlle.Application.Service.Implementations
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<UserDto?> AuthenticateAsync(string username, string password)
        {
            var user = await userRepository.GetUserByUsernameAsync(username);
            if (user == null || !VerifyPassword(user.PasswordHash, password))
            {
                return null;
            }

            return new UserDto
            { 
                Username = user.Username
            };
        }

        public async Task<bool> CreateUserAsync(string username, string password)
        {
            var user = new User
            {
                Username = username,
                PasswordHash = HashPassword(password)
            };

            await userRepository.CreateUserAsync(user);
            await userRepository.SaveChangesAsync();

            return true;
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            //TODO: Hash password

            string hashed = password;

            return hashed;
        }

        private bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            // Implement password verification logic here
            return hashedPassword == providedPassword; // Simplified for the example
        }
    }
}
