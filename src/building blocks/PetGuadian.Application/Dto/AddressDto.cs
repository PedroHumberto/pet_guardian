using PetGuardian.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuadian.Application.Dto
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string Street { get; set; } // Rua
        public string Number { get; set; } // N�mero
        public string Complement { get; set; } // Complemento
        public string Neighborhood { get; set; } // Bairro
        public string City { get; set; } // Cidade
        public string State { get; set; } // Estado
        public string PostalCode { get; set; } // CEP
        public Guid UserId { get; set; }
    }
}
