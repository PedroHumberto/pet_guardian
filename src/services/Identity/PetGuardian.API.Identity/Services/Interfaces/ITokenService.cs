using Microsoft.AspNetCore.Identity;

namespace PetGuardian.API.Identity.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(IdentityUser user);
    }
}
