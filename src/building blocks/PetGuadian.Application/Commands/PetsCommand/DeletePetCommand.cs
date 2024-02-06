
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.PetsCommand
{
    public class DeletePetCommand : Notifiable<Notification>, ICommand, IRequest<ICommandResult>
    {
        public DeletePetCommand(Guid petId, Guid userId)
        {
            PetId = petId;
            UserId = userId;
        }

        public Guid PetId { get; set; }
        public Guid UserId { get; set; }

        public void Execute()
        {
            AddNotifications(new Contract<DeletePetCommand>()
                .Requires()
                .IsEmpty(UserId, "User Id is necessary to delete")
            );
        }
    }
}