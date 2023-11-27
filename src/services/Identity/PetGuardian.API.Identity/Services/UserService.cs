using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetGuadian.Application.Commands.UserCommands;
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
            try{
                var user = new IdentityUser()
                {
                    UserName = newUser.Email,
                    Email = newUser.Email,
                    EmailConfirmed = true,
                };
                            
                var result = await _userManager.CreateAsync(user, newUser.Password);
                await _userManager.AddToRoleAsync(user, "Member");

                if(!result.Succeeded)
                {
                    throw new ArgumentException($"Failed to SingUp in: {result.Errors}");
                }

                var identityId = user.Id;
                var userCommand = new CreateUserCommand(Guid.Parse(identityId), newUser.UserName, user.Email, null);
                HttpClient client = new HttpClient();
                string json = JsonSerializer.Serialize(userCommand);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7057/api/User/create_user", content );
                string responseContent = await response.Content.ReadAsStringAsync();
                
                return result;

            }catch (Exception err )
            {
                Console.WriteLine(err.Message);
            }

            return IdentityResult.Failed();
        }
        public async Task<string> LogIn(LoginUser user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

            if (!result.Succeeded)
            {
                throw new ArgumentException($"Failed to log in: {result}");
            }

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
