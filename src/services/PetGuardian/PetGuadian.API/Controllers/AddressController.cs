using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetGuadian.Application.Commands.AddressCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto;
using PetGuadian.Application.Dto.AddressDto;
using PetGuadian.Application.Handlers;
using PetGuadian.Application.Services.Interfaces;


namespace PetGuadian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressHandler _handler;
        private readonly IAddressService _addressService;

        public AddressController(AddressHandler handler, IAddressService addressService)
        {
            _handler = handler;
            _addressService = addressService;
        }

        [HttpPost("create_address")]
        public async Task<GenericCommandResult> CreateAddress(CreateAddressCommand command)
        {
            var result = (GenericCommandResult) await _handler.Handle(command);
            
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressById(Guid addressId)
        {
            throw new NotImplementedException();

        }
    }
}
