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
                _cache.Remove(CacheKeyForPets(userId));
                _context.Pets.Remove(pet);
                await _context.Commit();
            }
        }
        public async Task<IEnumerable<Pet>> GetAllPetsByUserId(Guid userId)
        {
            var result = await _cache.GetOrCreateAsync(CacheKeyForPets(userId), async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                List<Pet> petUserList = await _context.Pets
                    .AsNoTracking()
                    .Where(p => p.UserId == userId)
                    .ToListAsync();
                    
                return petUserList;
            });
            return result ?? Enumerable.Empty<Pet>();
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

        public async Task<Pet> GetPetById(Guid userId, Guid petId)
        {
            if (_context is null)
            {
                throw new InvalidOperationException("Database context is not initialized.");
            }
            Pet? result = await _cache.GetOrCreateAsync(CacheKeyForPets(petId), async entry =>
            {  
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                Pet pet = await _context.Pets
                    .AsNoTracking()
                    .FirstAsync<Pet>(p => p.Id == petId && p.UserId == userId);

                if (pet is null)
                {
                    CustomApplicationExceptions.ThrowIfObjectIsNull(pet, "petId", "No pet found for the specified user.");
                }
                return pet;
            }) ?? throw new CustomApplicationExceptions("Pet is Null");
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private string CacheKeyForPets(Guid userId)
        {
            return $"UserPets:{userId}";
        }

        public async Task Update(Pet pet)
        {
            await Task.Run(() => _cache.Remove(CacheKeyForPets(pet.UserId)));
            _context.Pets.Update(pet);
            await _context.Commit();
        }
    }
}
