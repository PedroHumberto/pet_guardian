using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PetGuadian.Application.Commands.AddressCommand;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.AddressDto;
using PetGuadian.Application.Handlers.Contracts;
using PetGuadian.Application.Services.Interfaces;

namespace PetGuadian.Application.Handlers
{
    public class AddressHandler : IHandler<CreateAddressCommand>
    {
        private readonly IAddressService _service;

        public AddressHandler(IAddressService service)
        {
            _service = service;
        }

        public async Task<ICommandResult> Handle(CreateAddressCommand command)
        {
            //validate the command
            command.Execute();
            if(!command.IsValid)
            {
                return new GenericCommandResult(false, "Wrong Address", command.Notifications, HttpStatusCode.NotFound);
            }

            //mapping dto
            var createAddressDto = new CreateAddressDto(
                command.Street,
                command.Number,
                command.Complement,
                command.Neighborhood,
                command.City,
                command.State,
                command.PostalCode,
                command.UserId
            );

            //calling service
            await _service.CreateAddress(createAddressDto);

            //result
            return new GenericCommandResult(true, "Success", command, HttpStatusCode.OK);
        }
    }
}