using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.AddressDto;
using PetGuadian.Application.Dto.UserDto;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuardian.Tests.Services
{
    public class FakeAddressRepository : IAddressRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public async Task CreateAddress(Address address)
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<Address> GetAddressById(Guid addressId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAddress(Address updatedAddress)
        {
        }

    }
}