using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Commands.UserCommands;
using PetGuadian.Application.Dto.UserDto;
using PetGuadian.Application.Handlers.Contracts;
using PetGuadian.Application.Services.Interfaces;

namespace PetGuadian.Application.Handlers
{
    public class UserHandler : IHandler<CreateUserCommand>
    {
        private readonly IUserService _service;

        public UserHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<ICommandResult> Handle(CreateUserCommand command)
        {
            //validate user
            command.Execute();
            if(!command.IsValid)
            {
                return new GenericCommandResult(false, "Wrong Info in User", command.Notifications, HttpStatusCode.NotFound);
            }

            //mapping to User DTO
            var createUserDto = new CreateUserDto(
                command.UserIdentity, 
                command.Name, 
                command.Email, 
                command.AddressId);

            //call service
            await _service.CreateUser(createUserDto);

            return new GenericCommandResult(true, "Success", createUserDto, HttpStatusCode.OK);
        }
    }
}