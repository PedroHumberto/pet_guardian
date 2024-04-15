
using Flunt.Notifications;
using Flunt.Validations;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.VaccineCommands
{
    public class DeleteVaccineCommand : Notifiable<Notification>, ICommand
    {
        public DeleteVaccineCommand(Guid vaccineId, Guid petId)
        {
            VaccineId = vaccineId;
            PetId = petId;
        }

        public Guid VaccineId { get; set; }
        public Guid PetId { get; set; }

        public void Execute()
        {
            AddNotifications(new Contract<DeleteVaccineCommand>()
                .Requires()
                .IsEmpty(PetId, "User PetId is required to delete")
            );
        }
    }
}