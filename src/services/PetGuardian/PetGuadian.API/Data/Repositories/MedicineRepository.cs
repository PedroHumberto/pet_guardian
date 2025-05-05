using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.API.Data.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppContextDb _context;

        public MedicineRepository(AppContextDb context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public async Task CreateMedicine(Medicine medicine, CancellationToken cancellationToken)
        {
            await _context.Medicines.AddAsync(medicine, cancellationToken);
            await _context.Commit();
        }
        
        public Task<Medicine> GetMedicineById(Guid petId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMedicine(Guid MedicineId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}