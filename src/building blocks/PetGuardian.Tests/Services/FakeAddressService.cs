using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.AddressDto;
using PetGuadian.Application.Dto.UserDto;
using PetGuadian.Application.Services.Interfaces;

namespace PetGuardian.Tests.Services
{
    public class FakeAddressService : IAddressService
    {
        public async Task CreateAddress(CreateAddressDto addressDto)
        {
        }

        public Task<CreateAddressDto> GetAddressById(Guid addressId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAddress(CreateUserDto updatedAddressDto)
        {
            throw new NotImplementedException();
        }
    }
}