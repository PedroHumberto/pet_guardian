using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuardian.Tests.Services
{
    public class FakeMedicineRepository : IMedicineRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();


        public async Task CreateMedicine(Medicine Medicine, CancellationToken cancellationToken)
        {
        }

        public Task DeleteMedicine(Guid MedicineId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Medicine> GetMedicineById(Guid MedicineId)
        {
            throw new NotImplementedException();
        }
    }
}