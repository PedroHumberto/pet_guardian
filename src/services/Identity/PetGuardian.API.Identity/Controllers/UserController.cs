using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetGuardian.API.Identity.Models;
using PetGuardian.API.Identity.Services;
using PetGuardian.API.Identity.Services.Interfaces;

namespace PetGuardian.API.Identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost("singup")]
        public async Task<IActionResult> SingUp(CreateUser newUser)
        {
            var result = await _userService.SingUp(newUser);

            if(!result.Succeeded)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            var result = await _userService.LogIn(user);

            return Ok(result);
        }
    }
}
