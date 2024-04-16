using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.AddressCommand
{
    public class CreateAddressCommand : Notifiable<Notification>, ICommand, IRequest<ICommandResult>
    {
        public CreateAddressCommand()
        {
        }

        public CreateAddressCommand(string street, string number, string complement, string neighborhood, string city, string state, string postalCode)
        {
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public string Street {get; set; } // Rua
        public string Number {get; set; } // N�mero
        public string Complement {get; set; } // Complemento
        public string Neighborhood { get; set; } // Bairro
        public string City {get; set; } // Cidade
        public string State {get; set; } // Estado
        public string PostalCode {get; set; } // CEP
        public void Execute()
        {
            AddNotifications(new CustomContract<CreateAddressCommand>()
                .CustomRequires()
                .IsStringEmptyOrNull(Street, "Required field")
                .IsStringEmptyOrNull(Number, "Required field")
                .IsStringEmptyOrNull(Complement, "Required field")
                .IsStringEmptyOrNull(Neighborhood, "Required field")
                .IsStringEmptyOrNull(City, "Required field")
                .IsStringEmptyOrNull(State, "Required field")
                .IsStringEmptyOrNull(PostalCode, "Required field")
            );
        }
    }
}