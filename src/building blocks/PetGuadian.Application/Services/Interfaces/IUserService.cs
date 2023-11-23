

using PetGuadian.Application.Dto.UserDto;

namespace PetGuadian.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(CreateUserDto userDto);
        void UpdateUser(CreateUserDto updatedUserDto);
        Task<GetUserDto> GetUser(Guid userId);
        void DeleteUser(Guid userId);
    }
}