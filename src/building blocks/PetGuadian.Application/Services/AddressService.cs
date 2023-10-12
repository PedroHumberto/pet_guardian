using PetGuadian.Application.Dto;
using PetGuadian.Application.Interfaces;
using PetGuardian.Domain.Models.Interfaces;
using PetGuardian.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuadian.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public async Task CreateAddress(AddressDto addressDto)
        {
            var address = new Address(addressDto.Id, 
                addressDto.Street,
                addressDto.Number,
                addressDto.Complement,
                addressDto.Neighborhood,
                addressDto.City,
                addressDto.State,
                addressDto.PostalCode);

            await _addressRepository.CreateAddress(address);
        }

        public Task UpdateAddress(UserDto updatedAddressDto)
        {
            throw new NotImplementedException();
        }

        public Task GetAddressById(Guid addressId)
        {
            throw new NotImplementedException();
        }

    }
}
