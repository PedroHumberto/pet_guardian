using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetGuadian.Application;
using PetGuadian.Application.Interfaces;

namespace PetGuadian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            await _userService.CreateUser(userDto);
            return Ok(userDto);
        }
    }
}
