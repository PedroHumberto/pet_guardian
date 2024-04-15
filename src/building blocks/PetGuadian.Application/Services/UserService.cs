using PetGuadian.Application.Dto.UserDto;
using PetGuadian.Application.Services.Interfaces;
using PetGuardian.Domain.Repositories;
using PetGuardian.Domain.Models;

namespace PetGuadian.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUser(CreateUserDto userDto)
        {
            var user = new User(
                userDto.userIdentity,
                userDto.name,
                userDto.email);

            await _repository.CreateUser(user);
        }

        public void DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserDto> GetUser(Guid userId)
        {
            var user = await _repository.GetUser(userId);

            var userMapping = new GetUserDto(user.Id, user.Name, user.Email.EmailAddress, user.AddressId);

            return userMapping;

        }

        public void UpdateUser(CreateUserDto updatedUserDto)
        {
            throw new NotImplementedException();
        }
    }
}