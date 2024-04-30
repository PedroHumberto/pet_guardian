using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Commands.VeterinariansCommand;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Handlers.Pets
{
    public class SharePetWithVeterinarianHandler : IRequestHandler<SharePetWithVeterinarianCommand, ICommandResult>
    {
        private readonly IPetRepository _petRepository;
        private readonly IVeterinarianRepository _vetRepository;

        public SharePetWithVeterinarianHandler(IPetRepository petRepository, IVeterinarianRepository vetRepository)
        {
            _petRepository = petRepository;
            _vetRepository = vetRepository;
        }

        public async Task<ICommandResult> Handle(SharePetWithVeterinarianCommand request, CancellationToken cancellationToken)
        {
            request.Execute();
            if(!request.IsValid)
            {
                return new GenericCommandResult(false, "Request Error: ", request, HttpStatusCode.BadRequest);
            }

            //TRY-CATCH?
            var pet = await _petRepository.GetPetById(request.UserId, request.PetId);

            Veterinarian? veterinarian = await _vetRepository.GetVeterinarian(request.VetId);

            pet.SharePetToVet(veterinarian);
            veterinarian.setPetShared(pet);

            try
            {
                var result = await Task.WhenAll<bool>
                (
                    _petRepository.SharePetWithVeterinarian(pet),
                    _vetRepository.RegisterPet(veterinarian)
                );
                return new GenericCommandResult(true, "Shared: ", result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Result Error: ", ex.Message, HttpStatusCode.OK);
            }
        }
    }
}