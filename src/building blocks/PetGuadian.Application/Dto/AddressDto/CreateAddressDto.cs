﻿using PetGuardian.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuadian.Application.Dto.AddressDto
{
    public record CreateAddressDto(
        Guid id,
        string Street, 
        string Number, 
        string Complement, 
        string Neighborhood, 
        string City, 
        string State, 
        string PostalCode);
}
