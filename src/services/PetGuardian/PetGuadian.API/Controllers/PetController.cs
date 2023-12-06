using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetDto;
using PetGuadian.Application.Handlers;
using PetGuadian.Application.Handlers.Contracts;
using PetGuadian.Application.Services.Interfaces;


namespace PetGuadian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly PetHandler _handler;

        public PetController(IPetService petService, PetHandler handler)
        {
            _petService = petService;
            _handler = handler;
        }

        [HttpPost("create_pet")]
        public async Task<ICommandResult> CreatePet([FromBody]CreatePetCommand command)
        {
            var result = (GenericCommandResult)await _handler.Handle(command);
            return result;
        }

        [HttpGet("get_pet_by_userId")]
        public async Task<IActionResult> GetPetByUserId(Guid userId)
        {
            var pets = await _petService.GetAllPetsByUserId(userId);

            if (pets.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(pets);
        }
        [HttpGet("delete")]
        public async Task<ICommandResult> DeletePet([FromBody]DeletePetCommand command)
        {
            GenericCommandResult result = (GenericCommandResult) await _handler.Handle(command);

            return result;
        }

    }
}
