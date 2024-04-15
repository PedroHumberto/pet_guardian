using PetGuadian.Application.Dto.AddressDto;
using PetGuadian.Application.Dto.UserDto;


namespace PetGuadian.Application.Services.Interfaces
{
    public interface IAddressService
    {
        Task CreateAddress(CreateAddressDto addressDto);
        Task UpdateAddress(CreateUserDto updatedAddressDto);
        Task<CreateAddressDto> GetAddressById(Guid addressId);
    }
}
