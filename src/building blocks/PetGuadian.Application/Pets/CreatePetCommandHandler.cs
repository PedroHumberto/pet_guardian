using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Abstractions.Commands;
using PetGuardian.Domain.Abstractions;
using PetGuardian.Domain.Pets;
using PetGuardian.Domain.Users;

namespace PetGuadian.Application.Pets
{
    internal sealed class CreatePetCommandHandler : ICommandHandler<CreatePetCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePetCommandHandler(IUserRepository userRepository, IPetRepository petRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdAsync(request.userId, cancellationToken);
            if(user is null)
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }


            try{
                var pet = Pet.Create(
                request.petName,
                request.gender,
                request.species,
                request.birthDate,
                request.weight);

                await _petRepository.CreatePet(pet);

                //PRECISA DE COMUNICAR COM O USER PARA PASSAR A ID.

                return pet.Id;
            }catch
            {
                return Result.Failure<Guid>(PetErrors.Overlap);
            }

            
            throw new NotImplementedException();
        }
    }
}