using PetGuardian.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuardian.Domain.Repositories
{
    public interface IAddressRepository
    {
        Task CreateAddress(Address address);
        Task UpdateAddress(Address updatedAddress);
        Task<Address> GetAddressById(Guid addressId);
    }
}
