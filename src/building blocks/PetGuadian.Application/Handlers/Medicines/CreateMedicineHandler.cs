using System.Net;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.MedicineCommands;
using PetGuadian.Application.Commands.Results;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Handlers.Medicines
{
    public sealed class CreateMedicineHandler : IRequestHandler<CreateMedicineCommand, ICommandResult>
    {
        private readonly IMedicineRepository _repository;

        public CreateMedicineHandler(IMedicineRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateMedicineCommand request, CancellationToken cancellationToken)
        {
            request.Execute();
            if(!request.IsValid)
            {   
                return new GenericCommandResult(false, "InvalidCommand", request, HttpStatusCode.BadRequest);
            }

            var medicine = new Medicine
                (
                    request.PetId,
                    request.RemedyName,
                    request.Dosage,
                    request.Observations,
                    request.StartDate,
                    request.EndDate
                );
            try
            {
                await _repository.CreateMedicine(medicine, cancellationToken);
                return new GenericCommandResult(true, "Success", medicine, HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return new GenericCommandResult(false, "Cannot Add to Repository", ex, HttpStatusCode.BadRequest);
            }
        }
    }
}