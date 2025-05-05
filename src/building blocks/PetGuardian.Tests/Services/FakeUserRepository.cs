using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.UserDto;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuardian.Tests.Services
{
    public class FakeUserRepository : IUserRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public async Task CreateUser(User user, CancellationToken cancellationToken)
        {
        }


        public void DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public Task<GetUserDto> GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task InativateUser(Guid userId)
        {
            throw new NotImplementedException();
        }


        public void UpdateUser(CreateUserDto updatedUserDto)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User updatedUser)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

    }
}