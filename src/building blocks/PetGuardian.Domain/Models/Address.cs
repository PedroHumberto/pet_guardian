
using PetGuardian.Core.PetGuardianCore.DomainObjects;

namespace PetGuardian.Domain.Models
{
    public class Address : Entity
    {
        public string Street { get; private set; } // Rua
        public string Number { get; private set; } // N�mero
        public string Complement { get; private set; } // Complemento
        public string Neighborhood { get; private set; } // Bairro
        public string City { get; private set; } // Cidade
        public string State { get; private set; } // Estado
        public string PostalCode { get; private set; } // CEP

        protected Address() { }

        public Address(
            Guid id,
            string street, 
            string number, 
            string complement, 
            string neighborhood, 
            string city, 
            string state, 
            string postalCode
            ) : base(id)
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