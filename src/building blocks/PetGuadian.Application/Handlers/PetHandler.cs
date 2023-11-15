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
        IHandler<UpdatePetCommand>
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
                return new GenericCommandResult(false, "Wrong Info in Pet", command.Notifications, HttpStatusCode.NotFound);
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
    }
}