using System.Net;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetDto;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Handlers.Pets
{
    public class CreatePetHandler : IRequestHandler<CreatePetCommand, ICommandResult>

    {
        private readonly IPetRepository _repository;

        public CreatePetHandler(IPetRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            request.Execute();
            if (!request.IsValid)
            {
                return new GenericCommandResult(false, "Pet data is required", request.Notifications, HttpStatusCode.BadRequest);
            }

            CreatePetDto createPetDto = new CreatePetDto(
                request.PetName,
                request.Gender,
                request.Specie,
                request.BirthDate,
                request.Weight,
                request.UserId);

            var pet = new Pet(
                createPetDto.PetName,
                createPetDto.Gender,
                createPetDto.Specie,
                createPetDto.BirthDate,
                createPetDto.Weight);

            await _repository.CreatePet(pet, createPetDto.UserId, cancellationToken);

            return new GenericCommandResult(true, "Success", createPetDto, HttpStatusCode.Created);
        }
    }
}