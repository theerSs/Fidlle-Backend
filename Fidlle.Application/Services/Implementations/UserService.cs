using Fidlle.Application.IRepositories;
using Fidlle.Application.Service.Interfaces;
using Fidlle.Domain.Entities;
using Fidlle.Shared.Interfaces;

namespace Fidlle.Application.Service.Implementations
{
    public class UserService(IUserRepository userRepository, IPasswordService passwordService) : IUserService
    {
        public async Task<Guid?> AuthenticateAsync(string email, string password)
        {
            var user = await userRepository.GetUserByEmailAsync(email);
            if (user == null || !passwordService.VerifyPassword(user.PasswordHash, password))
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
                PasswordHash = passwordService.HashPassword(password)
            };

            await userRepository.CreateUserAsync(user);
            await userRepository.SaveChangesAsync();

            return true;
        }
    }
}
