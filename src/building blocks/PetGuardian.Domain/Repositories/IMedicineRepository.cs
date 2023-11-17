using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Domain.Models;

namespace PetGuardian.Domain.Repositories
{
    public interface IMedicineRepository
    {
        Task CreatMedicine(Medicine medicine);
        Task<IEnumerable<Medicine>> GetMedicineByPetId(Guid petId);
    }
}