using Fidlle.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fidlle.Application.UseCases.Interfaces
{
    public interface IAccountUseCases
    {
        Task<ClaimsPrincipal?> LoginUser(LoginDto loginDto, string authScheme);
        Task<bool> RegisterUser(RegisterDto registerDto);

    }
}
