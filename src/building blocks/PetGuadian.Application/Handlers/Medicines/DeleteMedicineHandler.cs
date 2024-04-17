using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.MedicineCommands;
using PetGuadian.Application.Commands.Results;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Handlers.Medicines
{
    public class DeleteMedicineHandler : IRequestHandler<DeleteMedicineCommand, ICommandResult>
    {
        private readonly IMedicineRepository _repository;

        public DeleteMedicineHandler(IMedicineRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(DeleteMedicineCommand request, CancellationToken cancellationToken)
        {
            request.Execute();
            if(!request.IsValid)
            {
                return new GenericCommandResult(false, "Request is Invalid", request, HttpStatusCode.BadRequest);
            }
            try
            {
                await _repository.DeleteMedicine(request.MedicineId, cancellationToken);
                return new GenericCommandResult(true, "Deleted was Successfull", request, HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                return new GenericCommandResult(false, "Bad Request", ex, HttpStatusCode.BadRequest);
            }
        }
    }
}