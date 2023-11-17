using Microsoft.EntityFrameworkCore;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;
using PetGuardian.Models.Models;
using System.Runtime.CompilerServices;

namespace PetGuadian.API.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AppContextDb _context;
        public IUnitOfWork UnitOfWork => _context;

        public PetRepository(AppContextDb context)
        {
            _context = context;
        }

        public async Task CreatePet(Pet pet, Guid userId)
        {
            //CRIAR EXCEPTIONS PARA VALIDAÇÕES -> ESTOU APENAS PREVININDO QUALQUER ERRO NESTE TRECHO.
            if(pet == null) 
            {
                throw new Exception("Error in PET");
            }
            //-----------------

            pet.AddUser(userId);

            await _context.Pets.AddAsync(pet);

            await _context.Commit();

        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pet>> GetAllPetsByUserId(Guid userId)
        {
            var petUserList = await _context.Pets.Where(p => p.UserId == userId).ToListAsync();

            return petUserList;
        }

        public async Task<Pet> GetPetMedicines(Guid petId)
        {
            var medicines = await _context.Medicines.Where(medicine => medicine.PetId == petId).ToListAsync();
            var pet = await _context.Pets.FirstAsync(pet => pet.Id == petId);

            foreach(var medicine in medicines)
            {
                pet.AddMecine(medicine);
            }

            return pet;
        }

        public async Task<Pet> GetPetById(Guid Id)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(p => p.Id == Id);

            return pet;
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
