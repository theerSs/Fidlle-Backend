using Fidlle.Application.Services.Interfaces;
using System.Security.Claims;


namespace Fidlle.Application.Services.Implementations
{
    public class ClaimsService : IClaimsService
    {
        public ClaimsPrincipal CreateClaimsPrincipal(Guid id, string authenticationScheme)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, authenticationScheme);
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
