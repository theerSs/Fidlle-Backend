using Fidlle.Application.Service.Interfaces;
using System.Security.Claims;


namespace Fidlle.Application.Service.Implementations
{
    public class ClaimsService : IClaimsService
    {
        public ClaimsPrincipal CreateClaimsPrincipal(Guid id, string authetnicationScheme)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, authetnicationScheme);
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
