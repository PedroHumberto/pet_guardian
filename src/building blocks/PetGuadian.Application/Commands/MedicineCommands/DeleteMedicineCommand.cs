using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.MedicineCommands
{
    public class DeleteMedicineCommand : Notifiable<Notification>, ICommand, IRequest<ICommandResult>
    {
        public DeleteMedicineCommand(Guid medicineId)
        {
            MedicineId = medicineId;
        }

        public Guid MedicineId { get; set; }
        public void Execute()
        {
            AddNotifications(new Contract<DeleteMedicineCommand>()
                .Requires()
                .IsEmpty(MedicineId, "Medicine Id is necessary to delete")
            );
        }
    }
}