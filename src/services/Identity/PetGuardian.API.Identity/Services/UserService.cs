using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetGuadian.Application.Commands.UserCommands;
using PetGuardian.API.Identity.Models;
using PetGuardian.API.Identity.Services.Interfaces;
using PetGuardian.Core.Exceptions;

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
            try
            {
                var user = new IdentityUser()
                {
                    UserName = newUser.Email,
                    Email = newUser.Email,
                    EmailConfirmed = true,
                };

                var result = await _userManager.CreateAsync(user, newUser.Password);
                await _userManager.AddToRoleAsync(user, "Member");

                CustomApplicationExceptions.ThrowIfResultIsNotSucceeded(result.Succeeded, "Error During Singup", $"{result.Errors}");

                var petResponse = await HttpPetGuardianCreateUser.CreateUserApi(user);

                return result;

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<string> LogIn(LoginUser user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

            CustomApplicationExceptions.ThrowIfResultIsNotSucceeded(result.Succeeded, "Error during login", $"{result}");

            var userToken = await _signInManager.UserManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == user.Email.ToUpper());

            if (userToken == null)
            {
                userToken = new IdentityUser();
            }
            var roles = await _userManager.GetRolesAsync(userToken);
            var token = await _tokenService.GenerateToken(userToken, roles);

            return token;
        }

    }
}
