using System.Net;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetDto;
using PetGuardian.Domain.Repositories;

namespace PetGuadian.Application.Handlers.Pets
{
    public class UpdatePetHandler: IRequestHandler<UpdatePetCommand, ICommandResult>
    {
        private readonly IPetRepository _repository;

        public UpdatePetHandler(IPetRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
        {
            request.Execute();
            if (!request.IsValid)
            {
                return new GenericCommandResult(false, "Data is Required", request.Notifications, HttpStatusCode.BadRequest);
            }

            var updatePet = await _repository.GetPetById(request.UserId, request.PetId);

            updatePet.Update(
                request.PetName,
                request.Gender,
                request.BirthDate,
                request.Weight);
                

            await _repository.Update(updatePet, cancellationToken);

            return new GenericCommandResult(true, "Update Successfull", request, HttpStatusCode.OK);
        }
    }
}