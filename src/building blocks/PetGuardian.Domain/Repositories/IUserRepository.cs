
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;

namespace PetGuardian.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task CreateUser(User user, CancellationToken cancellationToken);
        void UpdateUser(User updatedUser);
        Task<User> GetUser(Guid userId);
        Task InativateUser(Guid userId);
        Task<bool> SharePetWithVeterinarian(Guid vetId);
        Task<bool> RemovePetSharedWithVeterinarian(Guid vetId);
    }
}