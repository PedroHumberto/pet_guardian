using Microsoft.AspNetCore.Mvc;
using PetGuadian.Application;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Commands.UserCommands;
using PetGuadian.Application.Dto.UserDto;
using PetGuadian.Application.Handlers;
using PetGuadian.Application.Services.Interfaces;

namespace PetGuadian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserHandler _handler;

        public UserController(IUserService userService, UserHandler handler)
        {
            _userService = userService;
            _handler = handler;
        }

        [HttpPost("create_user")]
        public async Task<GenericCommandResult> CreateUser([FromBody]CreateUserCommand command)
        {
            var result = (GenericCommandResult)await _handler.Handle(command);
            return result;
        }
        [HttpPost("get_user")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var user = await _userService.GetUser(userId);

            return Ok(user);
        }
    }
}
