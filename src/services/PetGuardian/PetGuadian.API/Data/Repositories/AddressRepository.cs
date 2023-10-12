using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models.Interfaces;
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

        public IUnityOfWork IUnitOfWork => _context;

        public async Task CreateAddress(Address address)
        {
            await _context.Addresses.AddAsync(address);
        }

        public Task GetAddressById(Guid addressId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAddress(Address updatedAddress)
        {
            throw new NotImplementedException();
        }
    }
}
