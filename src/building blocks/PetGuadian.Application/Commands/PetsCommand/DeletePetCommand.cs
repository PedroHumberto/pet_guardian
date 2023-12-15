
using Flunt.Notifications;
using Flunt.Validations;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.PetsCommand
{
    public class DeletePetCommand : Notifiable<Notification>, ICommand
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