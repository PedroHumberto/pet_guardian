using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Dto.UserDto;
using PetGuadian.Application.Services.Interfaces;

namespace PetGuardian.Tests.Services
{
    public class FakeUserService : IUserService
    {
        public async Task CreateUser(CreateUserDto userDto)
        {
        }

        public void DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserDto> GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(CreateUserDto updatedUserDto)
        {
            throw new NotImplementedException();
        }


    }
}