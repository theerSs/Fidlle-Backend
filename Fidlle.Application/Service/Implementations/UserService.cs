using Fidlle.Application.DTO;
using Fidlle.Application.IRepositories;
using Fidlle.Application.Service.Interfaces;
using Fidlle.Domain.Entities;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Fidlle.Application.Service.Implementations
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly string pepper = "YourSecretPepperValue"; // Store this securely

        public async Task<Guid?> AuthenticateAsync(string email, string password)
        {
            var user = await userRepository.GetUserByEmailAsync(email);
            if (user == null || !VerifyPassword(user.PasswordHash, password))
            {
                return null;
            }

            return user.Id;
        }

        public async Task<bool> CreateUserAsync(string username, string email, string password)
        {
            var user = new User
            {
                Email = email,
                Username = username,
                PasswordHash = HashPassword(password)
            };

            await userRepository.CreateUserAsync(user);
            await userRepository.SaveChangesAsync();

            return true;
        }

        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password + pepper,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}:{hashed}";
        }

        private bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var parts = hashedPassword.Split(':');
            var salt = Convert.FromBase64String(parts[0]);
            var storedHash = parts[1];

            var providedHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: providedPassword + pepper,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000, // Increased iteration count
                numBytesRequested: 256 / 8));

            return storedHash == providedHash;
        }
    }
}
