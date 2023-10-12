using PetGuardian.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuardian.Domain.Models.Interfaces
{
    public interface IAddressRepository
    {
        Task CreateAddress(Address address);
        Task UpdateAddress(Address updatedAddress);
        Task GetAddressById(Guid addressId);
    }
}
