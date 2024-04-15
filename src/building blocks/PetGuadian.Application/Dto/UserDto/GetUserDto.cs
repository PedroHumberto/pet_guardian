using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuadian.Application.Dto.UserDto
{
    public record GetUserDto(Guid userIdentity, string name, string email, Guid? addressId);

}