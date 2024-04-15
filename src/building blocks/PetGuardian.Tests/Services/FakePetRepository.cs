using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.PetDto;
using PetGuadian.Application.Services.Interfaces;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuardian.Tests.Repositories
{
    public class FakePetRepository : IPetRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public async Task CreatePet(CreatePetDto pet)
        {
        }

        public Task CreatePet(Pet pet, Guid userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeletePet(Guid petId, Guid userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pet>> GetAllPetsByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Pet> GetPetById(Guid userId, Guid petId)
        {
            throw new NotImplementedException();
        }

        public Task<Pet> GetPetMedicines(Guid petId)
        {
            throw new NotImplementedException();
        }

        public Task Update(Pet pet, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}