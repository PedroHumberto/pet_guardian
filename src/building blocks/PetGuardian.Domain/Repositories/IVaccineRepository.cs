using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;

namespace PetGuardian.Domain.Repositories
{
    public interface IVaccineRepository : IRepository<Vaccine>
    {
        Task Create(Vaccine vaccine, CancellationToken cancellationToken);
        Task<IEnumerable<Vaccine>> GetAllVaccinesByPetId(Guid petId);
        Task Update(Vaccine vaccine);
        Task<Vaccine> GetVaccineById(Guid vaccineId, Guid petId);
        Task Delete(Guid vaccineId, Guid petId);
    }
}