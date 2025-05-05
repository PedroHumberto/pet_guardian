using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using PetGuadian.Application.Abstractions;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.Results;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Queries.MedicineQueries
{
    public class MedicineQueries : IQueryHandler<GetMedicineByIdQuerie, ICommandResult>
    {
        private readonly IMedicineRepository _repository;

        public MedicineQueries(IMedicineRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(GetMedicineByIdQuerie request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                return new GenericCommandResult(false, "Error in request", request, HttpStatusCode.BadRequest);
            }

            try
            {
                var medicine = await _repository.GetMedicineById(request.MedicineId);
                var response = new MedicineResponse
                (
                    medicine.RemedyName,
                    medicine.Dosage,
                    medicine.Observations,
                    medicine.StartDate,
                    medicine.EndDate,
                    medicine.PetId
                );

                return new GenericCommandResult(true, "Success Request", response, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Error during Repository Access", ex, HttpStatusCode.BadRequest);
            }

        }
    }
}