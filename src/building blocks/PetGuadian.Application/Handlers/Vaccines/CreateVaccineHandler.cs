using System.Net;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Commands.VaccineCommands;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Handlers.Vaccines
{
    public class CreateVaccineHandler : IRequestHandler<CreateVaccineCommand, ICommandResult>
    {
        private readonly IVaccineRepository _repository;

        public CreateVaccineHandler(IVaccineRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateVaccineCommand request, CancellationToken cancellationToken)
        {
            request.Execute();
            if(!request.IsValid)
            {
                return new GenericCommandResult(false, "Request Error", request, HttpStatusCode.BadRequest);

            }
            try
            {
                var vaccine = new Vaccine
                (
                    request.Name,
                    request.VaccinatedAt,
                    request.FirstVaccin,
                    request.PetId,
                    request.Notes
                );

                await _repository.Create(vaccine, cancellationToken);
                
                return new GenericCommandResult(true, "Succsess", vaccine, HttpStatusCode.Created);

            }catch(Exception ex)
            {
                return new GenericCommandResult(false, "Execption", ex, HttpStatusCode.BadRequest);
            }
            throw new NotImplementedException();
        }
    }
}