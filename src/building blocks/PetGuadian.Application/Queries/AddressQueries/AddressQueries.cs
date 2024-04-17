using System.Net;
using MediatR;
using PetGuadian.Application.Abstractions;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Queries.PetQueries;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Queries.AddressQueries
{
    public sealed class AddressQueries : IQueryHandler<GetAddressByIdQuerie, ICommandResult>
    {
        private readonly IAddressRepository _repository;

        public AddressQueries(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(GetAddressByIdQuerie request, CancellationToken cancellationToken)
        {
            if(request is null)
            {
                return new GenericCommandResult(false, "Request Problem", request, HttpStatusCode.BadRequest);
            }

            var address = await _repository.GetAddressById(request.AddressId);
            var addressDto = new AddressResponse
                (
                    address.Id,
                    address.Street,
                    address.Number,
                    address.Complement,
                    address.Neighborhood,
                    address.City,
                    address.State,
                    address.PostalCode
                );
            
            return new GenericCommandResult(true, "Success", addressDto, HttpStatusCode.OK);
        }
    }
}