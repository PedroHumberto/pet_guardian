using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.MedicineCommands;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.MedicineDto;
using PetGuadian.Application.Handlers.Contracts;
using PetGuadian.Application.Services.Interfaces;

namespace PetGuadian.Application.Handlers
{
    public class MedicineHandler : IHandler<CreateMedicineCommand>
    {
        private readonly IMedicineService _service;

        public MedicineHandler(IMedicineService service)
        {
            _service = service;
        }

        public async Task<ICommandResult> Handle(CreateMedicineCommand command)
        {
            //test the creation
            command.Execute();
            if(!command.IsValid)
            {
                return new GenericCommandResult(false, "Wrong data", command.Notifications, HttpStatusCode.BadRequest);
            }

            //Create DTO
            var createMedicineDto = new CreateMedicineDto(
                command.RemedyName,
                command.Dosage,
                command.Observations,
                command.StartDate,
                command.EndDate,
                command.PetId);
            
            await _service.CreateMedicine(createMedicineDto);

            return new GenericCommandResult(true, "Success", createMedicineDto, HttpStatusCode.Created);
        }
    }
}