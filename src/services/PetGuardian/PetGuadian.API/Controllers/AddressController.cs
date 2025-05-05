using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetGuadian.Application.Commands.AddressCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto;
using PetGuadian.Application.Dto.AddressDto;
using PetGuadian.Application.Handlers;


namespace PetGuadian.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _handler;

        public AddressController(IMediator handler)
        {
            _handler = handler;
        }

        [HttpPost("create_address")]
        public async Task<GenericCommandResult> CreateAddress([FromBody]CreateAddressCommand command)
        {
            var result = (GenericCommandResult) await _handler.Send(command);
            
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressById(Guid addressId)
        {
            throw new NotImplementedException();

        }
    }
}
