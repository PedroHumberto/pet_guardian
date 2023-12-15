using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using PetGuardian.Core.Exceptions;
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
        private readonly IMemoryCache _cache;

        public IUnitOfWork UnitOfWork => _context;

        public PetRepository(AppContextDb context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task CreatePet(Pet pet, Guid userId)
        {
            CustomApplicationExceptions.ThrowIfObjectIsNull(pet, "pet", "Object is Null");

            pet.AddUser(userId);

            await _context.Pets.AddAsync(pet);

            _cache.Remove(CacheKeyForPets(userId));

            await _context.Commit();

        }

        public async Task DeletePet(Guid petId, Guid userId)
        {
            Pet? pet = await _context.Pets.AsNoTracking().FirstOrDefaultAsync(p => p.Id == petId && p.UserId == userId);

            CustomApplicationExceptions.ThrowIfObjectIsNull(pet, "pet", "Pet is Null for delete");

            if (pet is not null)
            {
                _context.Pets.Remove(pet);

                await _context.Commit();
            }
        }
        public async Task<IEnumerable<Pet>> GetAllPetsByUserId(Guid userId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _cache.GetOrCreateAsync(CacheKeyForPets(userId), async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                List<Pet> petUserList = await _context.Pets.AsNoTracking().Where(p => p.UserId == userId).ToListAsync();

                if (!petUserList.Any())
                {
                    CustomApplicationExceptions.ThrowIfAListOfObjectsIsNullOrEmpty(petUserList, "userId", "No pets found for the specified user.");

                }
                return petUserList;
            });
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Pet> GetPetMedicines(Guid petId)
        {
            var medicines = await _context.Medicines.Where(medicine => medicine.PetId == petId).ToListAsync();
            var pet = await _context.Pets.AsNoTracking().FirstAsync(pet => pet.Id == petId);

            foreach (var medicine in medicines)
            {
                pet.AddMecine(medicine);
            }

            return pet;
        }

        public async Task<Pet> GetPetById(Guid id)
        {

            // Check if the data is already in the cache
            if (_cache.TryGetValue(CacheKeyForPets(id), out Pet? cachedPet))
            {
                CustomApplicationExceptions.ThrowIfObjectIsNull(cachedPet, "Cached Pet", "No cached pet found with the given ID.");

                return cachedPet;

            }
            Pet? pet = await _context.Pets.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            CustomApplicationExceptions.ThrowIfObjectIsNull(pet, "pet", "Pet is null here");

            return pet;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private string CacheKeyForPets(Guid userId)
        {

            return $"UserPets:{userId}";
        }


    }
}
