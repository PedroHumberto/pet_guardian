using System.Net;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Commands.UserCommands;
using PetGuardian.Domain.Models;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ICommandResult>
    {
        private readonly IUserRepository _repository;

        public CreateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.Execute();
            if(!request.IsValid)
            {
                return new GenericCommandResult(false, "Request Error", request, HttpStatusCode.BadRequest);
            }

            try
            {
                var user = new User
                (
                    request.UserIdentity,
                    request.Name,
                    request.Email
                );
                await _repository.CreateUser(user, cancellationToken);

                return new GenericCommandResult(true, "Succsess", user, HttpStatusCode.Created);

            }
            catch(Exception ex)
            {
                return new GenericCommandResult(false, "Execption", ex, HttpStatusCode.BadRequest);
            }
        }
    }
}