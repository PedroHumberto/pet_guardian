

using PetGuadian.Application.Dto.UserDto;

namespace PetGuadian.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(CreateUserDto userDto);
        void UpdateUser(CreateUserDto updatedUserDto);
        void GetUser(Guid userId);
        void DeleteUser(Guid userId);
    }
}