using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task CreatMedicine(Medicine medicine)
        {
            await _context.Medicines.AddAsync(medicine);
            await _context.Commit();
        }

        public Task<IEnumerable<Medicine>> GetMedicineByPetId(Guid petId)
        {
            throw new NotImplementedException();
        }
    }
}