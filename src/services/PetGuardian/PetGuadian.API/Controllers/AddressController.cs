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
            await _addressService.CreateAddress(addressDto);

            return Ok(addressDto);
        }
    }
}
