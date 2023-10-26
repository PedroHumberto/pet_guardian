using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PetGuardian.API.Identity.Models;
using PetGuardian.API.Identity.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetGuardian.API.Identity.Services
{
    public class TokenService : ITokenService
    {
        public async Task<string> GenerateToken(IdentityUser user, IList<string> roles)
        {
            var claimsIdentity = new ClaimsIdentity();
            
            claimsIdentity.AddClaim(new Claim("id", user.Id));
            claimsIdentity.AddClaim(new Claim("email", user.Email));
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            foreach (var role in roles)
            {
                claimsIdentity.AddClaim(new Claim("role", role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ASDAS5WE8T5Y6F4A5S8TT9QWE8REW8RQ4AS56D6"));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = signingCredentials,
                Expires = DateTime.UtcNow.AddHours(2),
                Subject = claimsIdentity
            };

            var handle = new JwtSecurityTokenHandler();
            var token = handle.CreateToken(tokenDescriptor);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
