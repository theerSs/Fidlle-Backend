using System.Security.Claims;

namespace Fidlle.Application.Service.Interfaces
{
    public interface IClaimsService
    {
        ClaimsPrincipal CreateClaimsPrincipal(string username, string authenticationScheme);
    }
}
