using Fidlle.Application.Service.Interfaces;
using System.Security.Claims;


namespace Fidlle.Application.Service.Implementations
{
    public class ClaimsService : IClaimsService
    {
        public ClaimsPrincipal CreateClaimsPrincipal(string email, string authetnicationScheme)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, authetnicationScheme);
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
