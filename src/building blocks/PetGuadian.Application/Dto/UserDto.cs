using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Models.Models;

namespace PetGuadian.Application
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public Guid AddressId { get; set; }
        public bool Deleted { get; set; }
    }
}