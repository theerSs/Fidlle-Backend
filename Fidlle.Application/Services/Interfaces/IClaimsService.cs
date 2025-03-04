using System.Security.Claims;

namespace Fidlle.Application.Services.Interfaces
{
    public interface IClaimsService
    {
        ClaimsPrincipal CreateClaimsPrincipal(Guid id, string authenticationScheme);
    }
}
