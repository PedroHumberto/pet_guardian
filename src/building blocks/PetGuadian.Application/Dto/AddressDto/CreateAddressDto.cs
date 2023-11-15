using PetGuardian.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuadian.Application.Dto.AddressDto
{
    public record CreateAddressDto(
        string Street, 
        string Number, 
        string Complement, 
        string Neighborhood, 
        string City, 
        string State, 
        string PostalCode, 
        Guid UserId);
}
