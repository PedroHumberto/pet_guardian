using PetGuardian.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuardian.Models.Models
{
    public class Address
    {
        public string Street { get; private set; } // Rua
        public string Number { get; private set; } // Número
        public string Complement { get; private set; } // Complemento
        public string Neighborhood { get; private set; } // Bairro
        public string City { get; private set; } // Cidade
        public string State { get; private set; } // Estado
        public PostalCode PostalCode { get; private set; } // CEP

        protected Address() { }

        public Address(string street, 
            string number, 
            string complement, 
            string neighborhood, 
            string city, 
            string state, 
            PostalCode postalCode)
        {
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            PostalCode = postalCode;
        }
    }
}