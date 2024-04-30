using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.API.Data.Repositories
{
    public class VeterinarianRepository : IVeterinarianRepository
    {
        private readonly AppContextDb _context;

        public VeterinarianRepository(AppContextDb context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task Create(Veterinarian veterinarian)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid veterinarianId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pet>> GetAllPetsShared()
        {
            throw new NotImplementedException();
        }

        public Task<Veterinarian> GetVeterinarian(Guid vetId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterPet(Veterinarian veterinarian)
        {
            try{
                _context.Veterinarians.Update(veterinarian);

                await _context.Commit();

                return true;
            }catch(Exception ex)
            {
                return false;
            }

        }

        public Task Update(Veterinarian veterinarian)
        {
            throw new NotImplementedException();
        }
    }
}