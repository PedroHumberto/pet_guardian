using System.Net;
using MediatR;
using PetGuadian.Application.Commands.Contracts;
using PetGuadian.Application.Commands.PetsCommand;
using PetGuadian.Application.Commands.Results;
using PetGuadian.Application.Dto.PetDto;
using PetGuadian.Application.Queries.PetQueries;
using PetGuadian.Application.Services.Interfaces;

namespace PetGuadian.Application.Handlers
{
    public class PetHandler :
        IRequestHandler<CreatePetCommand, ICommandResult>,
        IRequestHandler<UpdatePetCommand, ICommandResult>,
        IRequestHandler<DeletePetCommand, ICommandResult>,
        IRequestHandler<FindAllPetsByUserIdCommand, ICommandResult>,
        IRequestHandler<FindPetByIdCommand, ICommandResult>
    {
        private readonly IPetService _service;

        public PetHandler(IPetService service)
        {
            _service = service;
        }

        public async Task<ICommandResult> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            request.Execute();
            if (!request.IsValid)
            {
                return new GenericCommandResult(false, "Pet data is required", request.Notifications, HttpStatusCode.BadRequest);
            }

            CreatePetDto createPetDto = new CreatePetDto(
                request.PetName,
                request.Gender,
                request.Specie,
                request.BirthDate,
                request.Weight,
                request.UserId);

            await _service.CreatePet(createPetDto);

            return new GenericCommandResult(true, "Success", createPetDto, HttpStatusCode.Created);
        }

        public async Task<ICommandResult> Handle(DeletePetCommand command)
        {
            command.Execute();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "User Id is required", command.Notifications, HttpStatusCode.BadRequest);
            }

            await _service.DeletePet(command.PetId, command.UserId);

            return new GenericCommandResult(true, "Deleted With Succssess", command, HttpStatusCode.NoContent);
        }

        public async Task<ICommandResult> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
        {
            request.Execute();
            if (!request.IsValid)
            {
                return new GenericCommandResult(false, "Data is Required", request.Notifications, HttpStatusCode.BadRequest);
            }

            GetPetDto getPet = await _service.GetPetById(request.UserId, request.PetId);

            var updatedPet = new UpdatePetDto(
                getPet.Id,
                request.UserId,
                request.PetName,
                request.Gender,
                request.BirthDate,
                request.Weight);

            await _service.Update(updatedPet);

            return new GenericCommandResult(true, "Update Successfull", request, HttpStatusCode.NoContent);
        }

        public async Task<ICommandResult> Handle(DeletePetCommand request, CancellationToken cancellationToken)
        {
            request.Execute();
            if (!request.IsValid)
            {
                return new GenericCommandResult(false, "User Id is required", request.Notifications, HttpStatusCode.BadRequest);
            }

            await _service.DeletePet(request.PetId, request.UserId);

            return new GenericCommandResult(true, "Deleted With Success", request, HttpStatusCode.NoContent);
        }

        public async Task<ICommandResult> Handle(FindAllPetsByUserIdCommand request, CancellationToken cancellationToken)
        {
            try{
                var result = await _service.GetAllPetsByUserId(request.Id);
                return new GenericCommandResult(true, "Success", result, HttpStatusCode.NoContent);

            }catch(Exception ex){
                return new GenericCommandResult(false, $"Error: {ex.Message}", ex, HttpStatusCode.BadRequest);
            }
        }

        public async Task<ICommandResult> Handle(FindPetByIdCommand request, CancellationToken cancellationToken)
        {
            try{
                var result = await _service.GetPetById(request.UserId, request.PetId);
                return new GenericCommandResult(true, "Success", result, HttpStatusCode.NoContent);

            }catch(Exception ex){
                return new GenericCommandResult(false, $"Error: {ex.Message}", ex, HttpStatusCode.BadRequest);
            }

        }
    }
}