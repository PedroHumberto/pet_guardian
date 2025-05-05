using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;

namespace PetGuardian.Domain.Repositories
{
    public interface IVeterinarianRepository : IRepository<Veterinarian>
    {
        Task Create(Veterinarian veterinarian);
        Task Update(Veterinarian veterinarian);
        Task Delete(Guid veterinarianId);
        Task<IEnumerable<Pet>> GetAllPetsShared();
        Task<bool> RegisterPet(Veterinarian veterinarian);

        Task<Veterinarian> GetVeterinarian(Guid vetId);
    }
}