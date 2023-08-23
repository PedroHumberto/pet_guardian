using Microsoft.AspNetCore.Identity;
using PetGuardian.API.Identity.Models;

namespace PetGuardian.API.Identity.Services.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> SingUp(CreateUser newUser);
        Task<string> LogIn(LoginUser user);
    }
}
