using System.Net;
using MediatR;
using PetGuadian.Application.Commands.AddressCommand;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.AddressDto;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Handlers.Adresses
{
    public class CreateAddressHandler : IRequestHandler<CreateAddressCommand, ICommandResult>
    {
        private readonly IAddressRepository _repository;


        public CreateAddressHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            //validate the command
            command.Execute();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Wrong Address", command.Notifications, HttpStatusCode.BadRequest);
            }

            //mapping dto
            var createAddressDto = new CreateAddressDto(
                Guid.NewGuid(),
                command.Street,
                command.Number,
                command.Complement,
                command.Neighborhood,
                command.City,
                command.State,
                command.PostalCode
            );


            var address = new Address(
                createAddressDto.id,
                createAddressDto.Street,
                createAddressDto.Number,
                createAddressDto.Complement,
                createAddressDto.Neighborhood,
                createAddressDto.City,
                createAddressDto.State,
                createAddressDto.PostalCode
                );

            await _repository.CreateAddress(address);

            //result
            return new GenericCommandResult(true, "Success", createAddressDto, HttpStatusCode.Created);
        }
    }
}