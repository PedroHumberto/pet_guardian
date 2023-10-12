using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetGuadian.Application.Dto;
using PetGuadian.Application.Interfaces;

namespace PetGuadian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        [HttpPost("createAddress")]
        public async Task<IActionResult> CreateAddress(AddressDto addressDto)
        {
            var createdAddress = await _addressService.CreateAddress(addressDto);

            return CreatedAtAction(nameof(GetAddressById), new { Id = addressDto.Id}, createdAddress);
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressById(Guid addressId)
        {
            var address = await _addressService.GetAddressById(addressId);

            return Ok(address);
        }
    }
}
