using System.Net;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetDto;
using PetGuadian.Application.Handlers.Contracts;
using PetGuadian.Application.Services.Interfaces;

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
            if(!command.IsValid)
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
            return new GenericCommandResult(true, "Success", createPetDto, HttpStatusCode.OK);
        }

        public async Task<ICommandResult> Handle(UpdatePetCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<ICommandResult> Handle(DeletePetCommand command)
        {
            command.Execute();
            if(!command.IsValid)
            {
                return new GenericCommandResult(false, "User Id is required", command.Notifications, HttpStatusCode.NotFound);
            }

            await _service.DeletePet(command.PetId, command.UserId);

            return new GenericCommandResult(true, "Deleted With Succssess", command, HttpStatusCode.NoContent);
        }
    }
}