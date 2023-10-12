using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Models.Models;

namespace PetGuardian.Domain.Models.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        void UpdateUser(User updatedUser);
        void GetUser(Guid userId);
        Task InativateUser(Guid userId);
    }
}