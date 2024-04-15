using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;


namespace PetGuardian.Domain.Repositories
{
    public interface IPetRepository : IRepository<Pet>
    {
        Task CreatePet(Pet pet, Guid userId, CancellationToken cancellationToken);
        Task<IEnumerable<Pet>> GetAllPetsByUserId(Guid userId);
        Task Update(Pet pet, CancellationToken cancellationToken);
        Task<Pet> GetPetMedicines(Guid petId);
        Task<Pet> GetPetById(Guid userId, Guid petId);
        Task DeletePet(Guid petId, Guid userId, CancellationToken cancellationToken);
    }
}
