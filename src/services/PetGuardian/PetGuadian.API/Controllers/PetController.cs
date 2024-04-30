using Microsoft.AspNetCore.Mvc;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using System.Net;
using MediatR;
using PetGuadian.Application.Queries.PetQueries;
using PetGuadian.Application.Commands.VeterinariansCommand;


namespace PetGuadian.API.Controllers
{
    /// <summary>
    /// Controller for Pet related operations
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IMediator _handler;

        public PetController(IMediator handler)
        {
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
            var result = (GenericCommandResult)await _handler.Send(command);
            return result;
        }

        /// <summary>
        /// Retrieves all pets associated with a given user ID
        /// </summary>
        /// <param name="userId">The ID of the user whose pets are to be retrieved</param>
        /// <returns>A list of pets or a not found result</returns>
        [HttpGet("get_pets_by_userId")]
        public async Task<ICommandResult> GetAllPetsByUserId([FromQuery] FindAllPetsByUserIdQuerie request)
        {
            var result = (GenericCommandResult)await _handler.Send(request);
            return result;
        }

        /// <summary>
        /// Deletes a pet based on the provided command
        /// </summary>
        /// <param name="command">Command containing the details of the pet to be deleted</param>
        /// <returns>A result indicating success or failure of pet deletion</returns>
        [HttpGet("delete")]
        public async Task<ICommandResult> DeletePet([FromBody] DeletePetCommand command)
        {
            GenericCommandResult result = (GenericCommandResult)await _handler.Send(command);
            return result;
        }

        /// <summary>
        /// Retrieves a specific pet by user ID and pet ID
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="petId">The ID of the pet to be retrieved</param>
        /// <returns>The requested pet or an internal server error if an exception occurs</returns>
        [HttpGet("get_pet/{userId}/{petId}")]
        public async Task<ICommandResult> GetPetById(FindPetByIdQuerie command)
        {
            var result = await _handler.Send(command);
            return result;
        }

        [HttpPatch("update")]
        public async Task<ICommandResult> UpdatePet([FromBody] UpdatePetCommand command)
        {
            try
            {
                GenericCommandResult result = (GenericCommandResult)await _handler.Send(command);
                return result;
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, $"Internal Server Error: {ex.Message} ", ex, HttpStatusCode.BadRequest);
            }
        }

        [HttpPatch("share-pet")]
        public async Task<ICommandResult> SharePet([FromBody] SharePetWithVeterinarianCommand command)
        {
            try
            {
                GenericCommandResult result = (GenericCommandResult)await _handler.Send(command);
                return result;
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, $"Internal Server Error: {ex.Message} ", ex, HttpStatusCode.BadRequest);
            }
        }
    }
}
