
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;

namespace PetGuardian.Domain.Repositories
{
    public interface IMedicineRepository : IRepository<Medicine>
    {
        Task CreatMedicine(Medicine medicine);
        Task<IEnumerable<Medicine>> GetMedicineByPetId(Guid petId);
    }
}