using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuadian.Application.Interfaces;
using PetGuardian.Domain.Repositories;
using PetGuardian.Models.Models;

namespace PetGuadian.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUser(UserDto userDto)
        {
            var user = new User(userDto.Id, userDto.Name, userDto.Email, userDto.Cpf);

            await _repository.CreateUser(user);

            throw new NotImplementedException();
        }

        public void DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserDto updatedUserDto)
        {
            throw new NotImplementedException();
        }
    }
}