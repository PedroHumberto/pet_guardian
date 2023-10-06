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
        public async Task<string> GenerateToken(IdentityUser user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("id", user.Id),
                new Claim("email", user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ASDAS5WE8T5Y6F4A5S8TT9QWE8REW8RQ4AS56D6"));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddMinutes(60),
                    claims: claims,
                    signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
