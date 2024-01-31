using System.Net;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetDto;
using PetGuadian.Application.Handlers.Contracts;
using PetGuadian.Application.Services.Interfaces;
using PetGuardian.Models.Models;

namespace PetGuadian.Application.Handlers
{
    public class PetHandler :
        IHandler<CreatePetCommand>,
        IHandler<UpdatePetCommand>,
        IHandler<DeletePetCommand>
    {
        private readonly IPetService _service;

        public PetHandler(IPetService service)
        {
            _service = service;
        }

        public async Task<ICommandResult> Handle(CreatePetCommand command)
        {
            //Fail Test Verification
            command.Execute();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Pet data is required", command.Notifications, HttpStatusCode.BadRequest);
            }

            //gerar CreatePetDTO
            CreatePetDto createPetDto = new CreatePetDto(
                command.PetName,
                command.Gender,
                command.Specie,
                command.BirthDate,
                command.Weight,
                command.UserId);

            //salvar
            await _service.CreatePet(createPetDto);

            //retornar o resultado
            return new GenericCommandResult(true, "Success", createPetDto, HttpStatusCode.Created);
        }

        public async Task<ICommandResult> Handle(UpdatePetCommand command)
        {
            command.Execute();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Data is Required", command.Notifications, HttpStatusCode.BadRequest);
            }

            var updatedPet = new UpdatePetDto(
                command.PetId,
                command.UserId,
                command.PetName,
                command.Gender,
                command.BirthDate,
                command.Weight);


            await _service.Update(updatedPet);

            return new GenericCommandResult(true, "Update Successfull", command, HttpStatusCode.NoContent);
        }

        public async Task<ICommandResult> Handle(DeletePetCommand command)
        {
            command.Execute();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "User Id is required", command.Notifications, HttpStatusCode.BadRequest);
            }

            await _service.DeletePet(command.PetId, command.UserId);

            return new GenericCommandResult(true, "Deleted With Succssess", command, HttpStatusCode.NoContent);
        }
    }
}