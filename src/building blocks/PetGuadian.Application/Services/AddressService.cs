
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;
using PetGuadian.Application.Services.Interfaces;
using PetGuadian.Application.Dto.UserDto;
using PetGuadian.Application.Dto.AddressDto;

namespace PetGuadian.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task CreateAddress(CreateAddressDto addressDto)
        {
            var address = new Address(
                addressDto.id,
                addressDto.Street,
                addressDto.Number,
                addressDto.Complement,
                addressDto.Neighborhood,
                addressDto.City,
                addressDto.State,
                addressDto.PostalCode
                );

            await _addressRepository.CreateAddress(address);

            

        }

        public Task UpdateAddress(CreateUserDto updatedAddressDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateAddressDto> GetAddressById(Guid addressId)
        {

            var address = await _addressRepository.GetAddressById(addressId);

            var addressDto = new CreateAddressDto(address.Id ,address.Street, address.Number, address.Complement, address.Neighborhood, address.City, address.State, address.PostalCode);

            return addressDto;
        }

    }
}
