using System.Net;
using PetGuadian.Application.Abstractions;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetDto;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Queries.PetQueries
{
    public class PetQueries : 
        IQueryHandler<FindPetByIdQuerie, ICommandResult>,
        IQueryHandler<FindAllPetsByUserIdQuerie, ICommandResult>
    {
        private readonly IPetRepository _petRepository;

        public PetQueries(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<ICommandResult> Handle(FindPetByIdQuerie request, CancellationToken cancellationToken)
        {

            if (request is null)
            {
                return new GenericCommandResult(false, "Wrong Request", request, HttpStatusCode.BadRequest);
            }

            var pet = await _petRepository.GetPetById(request.UserId, request.PetId);

            var petDto = new PetResponse(pet.Id, 
                pet.PetName, 
                pet.Gender, 
                pet.Specie,
                pet.BirthDate,
                pet.GetPetAge(),
                pet.Weight
                );
            
            return new GenericCommandResult(true, "Success", petDto, HttpStatusCode.OK);
        }

        public async Task<ICommandResult> Handle(FindAllPetsByUserIdQuerie request, CancellationToken cancellationToken)
        {
            if(request is null)
            {
                return new GenericCommandResult(false, "problem with request", request, HttpStatusCode.BadRequest);
            }

            var allPets = await _petRepository.GetAllPetsByUserId(request.Id);


            var petResponseList = new List<PetResponse>();
            foreach (var pet in allPets)
            {
                PetResponse? response = new PetResponse(
                    pet.Id,
                    pet.PetName,
                    pet.Gender,
                    pet.Specie,
                    pet.BirthDate,
                    pet.GetPetAge(),
                    pet.Weight);

                    petResponseList.Add(response);
            }

            return new GenericCommandResult(true, "Success", petResponseList, HttpStatusCode.OK);        }
    }
}