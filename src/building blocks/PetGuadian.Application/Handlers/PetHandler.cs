using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetDto;
using PetGuadian.Application.Handlers.Contracts;
using PetGuadian.Application.Interfaces;

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

        public ICommandResult Handle(CreatePetCommand command)
        {
            //Fail Test Verification
            command.Execute();
            if(!command.IsValid)
            {
                return new GenericCommandResult(false, "Wrong Info in Pet", command.Notifications);
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
            _service.CreatePet(createPetDto);

            //retornar o resultado
            return new GenericCommandResult(true, "Success", createPetDto);
        }

        public ICommandResult Handle(UpdatePetCommand command)
        {
            throw new NotImplementedException();
        }
    }
}