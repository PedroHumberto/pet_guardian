using System.Drawing;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetGuadian.Application;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Commands.UserCommands;
using PetGuadian.Application.Dto.UserDto;
using PetGuadian.Application.Handlers;

namespace PetGuadian.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _handler;

        public UserController(IMediator handler)
        {
            _handler = handler;
        }

        [HttpPost("create_user")]
        public async Task<GenericCommandResult> CreateUser([FromBody]CreateUserCommand command)
        {
            var result = (GenericCommandResult)await _handler.Send(command);
            return result;
        }
        [HttpGet("get_user/{userId}")]
        public async Task<GenericCommandResult> GetUserById(Guid userId)
        {
            var result = (GenericCommandResult)await _handler.Send(userId);

            return result;
        }

        [HttpPost("share_pet/{petId}")]
        public async Task<GenericCommandResult> SharePetWithVeterinarian(Guid petId)
        {
            var result = (GenericCommandResult)await _handler.Send(petId);
            return result;
        }
        
    }
}
