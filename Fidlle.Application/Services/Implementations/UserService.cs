using Fidlle.Application.IRepositories;
using Fidlle.Application.Services.Interfaces;
using Fidlle.Domain.Entities;
using Fidlle.Shared.Exceptions;
using Fidlle.Shared.Interfaces;

namespace Fidlle.Application.Services.Implementations
{
    public class UserService(IUserRepository userRepository, IPasswordService passwordService) : IUserService
    {
        public async Task<Guid?> AuthenticateAsync(string email, string password)
        {
            var user = await userRepository.GetUserByEmailAsync(email);
            if (user == null || !passwordService.VerifyPassword(user.PasswordHash, password))
            {
                throw new UnauthorizedAccessException("Wrong email or password");
            }

            return user.Id;
        }

        public async Task<bool> CreateUserAsync(string username, string email, string password)
        {
            var existingEmailUser = await userRepository.GetUserByEmailAsync(email);
            if (existingEmailUser != null)
            {
                throw new BadRequestException("A user with this email already exists.");
            }

            var existingUsernameUser = await userRepository.GetUserByUsernameAsync(username);
            if (existingUsernameUser != null){
                throw new BadRequestException("A user with this username already exists.");
            }

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
