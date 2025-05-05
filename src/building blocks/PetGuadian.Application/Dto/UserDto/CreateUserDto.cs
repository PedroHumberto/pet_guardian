using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Domain.Models;

namespace PetGuadian.Application.Dto.UserDto
{
    public record CreateUserDto(
        Guid userIdentity,
        string name, 
        string email, 
        Guid? addressId);

}