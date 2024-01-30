using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.MedicineCommands;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetDto;
using PetGuadian.Application.Handlers;
using PetGuadian.Application.Handlers.Contracts;
using PetGuadian.Application.Services.Interfaces;
using PetGuardian.Domain.Models;
using Microsoft.AspNetCore.Authorization;


namespace PetGuadian.API.Controllers
{
    /// <summary>
    /// Controller for Pet related operations
    /// </summary>
    [Route("api/v1/[controller]")]
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

        /// <summary>
        /// Creates a new pet
        /// </summary>
        /// <param name="command">Command containing the details of the pet to be created</param>
        /// <response code="200">Returns the requested pet</response>
        /// <returns>A result indicating success or failure of pet creation</returns>
        [HttpPost("create_pet")]
        public async Task<ICommandResult> CreatePet([FromBody] CreatePetCommand command)
        {
            var result = (GenericCommandResult)await _handler.Handle(command);
            return result;
        }

        /// <summary>
        /// Retrieves all pets associated with a given user ID
        /// </summary>
        /// <param name="userId">The ID of the user whose pets are to be retrieved</param>
        /// <returns>A list of pets or a not found result</returns>
        [HttpGet("get_pets_by_userId")]
        public async Task<IActionResult> GetPetByUserId(Guid userId)
        {
            var pets = await _petService.GetAllPetsByUserId(userId);
            if (pets.IsNullOrEmpty())
            {
                return NotFound("No pets found for the given user.");
            }
            return Ok(pets);
        }

        /// <summary>
        /// Deletes a pet based on the provided command
        /// </summary>
        /// <param name="command">Command containing the details of the pet to be deleted</param>
        /// <returns>A result indicating success or failure of pet deletion</returns>
        [HttpGet("delete")]
        public async Task<ICommandResult> DeletePet([FromBody] DeletePetCommand command)
        {
            GenericCommandResult result = (GenericCommandResult)await _handler.Handle(command);
            return result;
        }

        /// <summary>
        /// Retrieves a specific pet by user ID and pet ID
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="petId">The ID of the pet to be retrieved</param>
        /// <returns>The requested pet or an internal server error if an exception occurs</returns>
        [HttpGet("get_pet/{userId}/{petId}")]
        public async Task<IActionResult> GetPetById(Guid userId, Guid petId)
        {
            try
            {
                var pet = await _petService.GetPetById(userId, petId);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
    }
}
