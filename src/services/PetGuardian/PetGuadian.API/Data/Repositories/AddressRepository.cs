using Microsoft.EntityFrameworkCore;
using PetGuadian.Application.Dto;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Repositories;
using PetGuardian.Models.Models;

namespace PetGuadian.API.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppContextDb _context;

        public AddressRepository(AppContextDb context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public IUnitOfWork IUnitOfWork => _context;

        public async Task CreateAddress(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.Commit();
        }

        public async Task<Address> GetAddressById(Guid addressId)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == addressId);

            return address;
        }

        public Task UpdateAddress(Address updatedAddress)
        {
            throw new NotImplementedException();
        }
    }
}
