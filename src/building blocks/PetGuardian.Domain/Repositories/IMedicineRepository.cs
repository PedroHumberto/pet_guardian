
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;

namespace PetGuardian.Domain.Repositories
{
    public interface IMedicineRepository : IRepository<Medicine>
    {
        Task CreateMedicine(Medicine Medicine, CancellationToken cancellationToken);
        Task<Medicine> GetMedicineById(Guid MedicineId);
        Task DeleteMedicine(Guid MedicineId, CancellationToken cancellationToken);
    }
}