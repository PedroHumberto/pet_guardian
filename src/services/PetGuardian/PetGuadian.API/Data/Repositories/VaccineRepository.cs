using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PetGuardian.Core.Exceptions;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.API.Data.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly AppContextDb _context;
        private readonly IMemoryCache _cache;

        public VaccineRepository(AppContextDb context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task Create(Vaccine vaccine)
        {
            if(vaccine is null){
                throw new CustomApplicationExceptions("Object is null");
            }
            await _context.Vaccines.AddAsync(vaccine);

            _cache.Remove(key: CacheKeyForVaccine(vaccine.PetId));

            await _context.Commit();
        }

        public async Task Delete(Guid vaccineId, Guid petId)
        {
            var vaccine = await _context.Vaccines
                .FirstAsync(v => v.Id == vaccineId && v.PetId == petId);

            _context.Vaccines.Remove(vaccine);
            await _context.Commit();
        }

        public async Task<IEnumerable<Vaccine>> GetAllVaccinesByPetId(Guid petId)
        {
            var vaccines = await _cache.GetOrCreateAsync(CacheKeyForVaccine(petId), async entry => {
                
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                List<Vaccine> vaccineList = await _context.Vaccines
                    .AsNoTracking()
                    .Where(v => v.PetId == petId)
                    .ToListAsync();

                return vaccineList;
            });

            return vaccines ?? Enumerable.Empty<Vaccine>();
        }

        public async Task<Vaccine> GetVaccineById(Guid vaccineId, Guid petId)
        {

            var vaccine = await _context.Vaccines
                .FirstAsync(v => v.Id == vaccineId && v.PetId == petId);
            if(vaccine is null){
                throw new CustomApplicationExceptions("Error in Vaccine Id");
            }
            return vaccine;        
        }

        public async Task Update(Vaccine vaccine)
        {
            _cache.Remove(key: CacheKeyForVaccine(vaccine.PetId));

            _context.Vaccines.Update(vaccine);
            await _context.Commit();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        private string CacheKeyForVaccine(Guid petId)
        {
            return $"PetsVaccines:{petId}";
        }
        
    }
}