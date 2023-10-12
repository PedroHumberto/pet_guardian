using Microsoft.EntityFrameworkCore;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models.Interfaces;
using PetGuardian.Models.Models;

namespace PetGuadian.API.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AppContextDb _context;

        public PetRepository(AppContextDb context)
        {
            _context = context;
        }

        public IUnityOfWork IUnitOfWork => _context;

        public async Task CreatePet(Pet pet, Guid userId)
        {
            pet.AddUser(userId);

            await _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync();
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

        public async Task<Pet> GetPetById(Guid Id)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(p => p.Id == Id);

            return pet;
        }
    }
}
