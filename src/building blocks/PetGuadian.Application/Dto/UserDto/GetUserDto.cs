using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuadian.Application.Dto.UserDto
{
    public class GetUserDto
    {
        public GetUserDto(Guid userIdentity, string name, string email, Guid? addressId)
        {
            UserIdentity = userIdentity;
            Name = name;
            Email = email;
            AddressId = addressId;
        }

        public Guid UserIdentity { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? AddressId { get; set; }
    }
}