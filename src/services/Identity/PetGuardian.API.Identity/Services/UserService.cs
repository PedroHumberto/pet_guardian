using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetGuardian.API.Identity.Models;
using PetGuardian.API.Identity.Services.Interfaces;

namespace PetGuardian.API.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<IdentityResult> SingUp(CreateUser newUser)
        {
            var user = new IdentityUser()
            {
                UserName = newUser.UserName,
                Email = newUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);

            return result;
        }
        public async Task<string> LogIn(LoginUser user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);

            if (!result.Succeeded)
            {
                throw new ArgumentException($"Failed to log in: {result}");
            }

            var userToken = await _signInManager.UserManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == user.UserName.ToUpper());

            var token = await _tokenService.GenerateToken(userToken);

            return token;
        }
    }
}
