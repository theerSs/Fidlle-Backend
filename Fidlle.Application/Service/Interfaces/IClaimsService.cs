using System.Security.Claims;

namespace Fidlle.Application.Service.Interfaces
{
    public interface IClaimsService
    {
        ClaimsPrincipal CreateClaimsPrincipal(Guid id, string authenticationScheme);
    }
}
