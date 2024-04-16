using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetDto;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Queries.PetQueries
{
    public class PetQueries : 
        IRequestHandler<FindPetByIdCommand, ICommandResult>,
        IRequestHandler<FindAllPetsByUserIdCommand, ICommandResult>
    {
        private readonly IPetRepository _petRepository;

        public PetQueries(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }


        public async Task<ICommandResult> Handle(FindPetByIdCommand request, CancellationToken cancellationToken)
        {

            if (request is null)
            {
                new GenericCommandResult(false, "Pet data is required", request, HttpStatusCode.BadRequest);
            }

            var pet = await _petRepository.GetPetById(request.UserId, request.PetId);

            var petDto = new GetPetDto(pet.Id, 
                pet.PetName, 
                pet.Gender, 
                pet.Specie,
                pet.BirthDate,
                pet.GetPetAge(),
                pet.Weight
                );
            
            return new GenericCommandResult(true, "Success", petDto, HttpStatusCode.OK);
        }

        public Task<ICommandResult> Handle(FindAllPetsByUserIdCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}