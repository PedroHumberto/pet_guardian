using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.MedicineCommands
{
    public class CreateMedicineCommand : Notifiable<Notification>, ICommand, IRequest<ICommandResult>
    {
        public CreateMedicineCommand()
        {
        }

        public CreateMedicineCommand(string remedyName, string dosage, string observations, DateTime startDate, DateTime? endDate, Guid petId)
        {
            RemedyName = remedyName;
            Dosage = dosage;
            Observations = observations;
            StartDate = startDate;
            EndDate = endDate;
            PetId = petId;
        }

        public string RemedyName { get; set; }
        public string Dosage { get; set; }
        public string Observations { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid PetId { get; set; }
        public void Execute()
        {
            AddNotifications(new Contract<CreateMedicineCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(RemedyName, 3, "The name need more than 3 characteres")
                .IsGreaterOrEqualsThan(Observations, 15, "Observations needs more than 15 char")
            );
        }
    }
}