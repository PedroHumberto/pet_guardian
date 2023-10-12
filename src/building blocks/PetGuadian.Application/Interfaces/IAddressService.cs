using PetGuadian.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuadian.Application.Interfaces
{
    public interface IAddressService
    {
        Task<AddressDto> CreateAddress(AddressDto addressDto);
        Task UpdateAddress(UserDto updatedAddressDto);
        Task<AddressDto> GetAddressById(Guid addressId);
    }
}
