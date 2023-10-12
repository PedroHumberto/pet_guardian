using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Models.Models;

namespace PetGuadian.Application.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(UserDto userDto);
        void UpdateUser(UserDto updatedUserDto);
        void GetUser(Guid userId);
        void DeleteUser(Guid userId);
    }
}