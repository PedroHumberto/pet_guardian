
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;

namespace PetGuardian.Domain.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task CreateAddress(Address address);
        Task UpdateAddress(Address updatedAddress);
        Task<Address> GetAddressById(Guid addressId);
    }
}
