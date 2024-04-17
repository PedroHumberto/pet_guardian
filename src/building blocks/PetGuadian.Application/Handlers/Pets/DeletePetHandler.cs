using System.Net;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Handlers.Pets
{
    public class DeletePetHandler : IRequestHandler<DeletePetCommand, ICommandResult>

    {
        private readonly IPetRepository _repository;

        public DeletePetHandler(IPetRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(DeletePetCommand request, CancellationToken cancellationToken)
        {

            request.Execute();
            if (!request.IsValid)
            {
                return new GenericCommandResult(false, "User Id is required", request.Notifications, HttpStatusCode.BadRequest);
            }

            await _repository.DeletePet(request.PetId, request.UserId, cancellationToken);

            return new GenericCommandResult(true, "Deleted With Succssess", request, HttpStatusCode.NoContent);
        }
    }
}