using PetGuardian.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGuardian.Domain.Models.Interfaces
{
    public interface IPetRepository
    {
        Task CreatePet(Pet pet, Guid userId);
        Task<IEnumerable<Pet>> GetAllPetsByUserId(Guid userId);
        Task<Pet> GetPetById(Guid Id);
        Task Delete(Guid Id);
    }
}
