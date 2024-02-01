
using Flunt.Notifications;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.VaccineCommands
{
    public class CreateVaccineCommand : Notifiable<Notification>, ICommand
    {

        public CreateVaccineCommand(){}

        public CreateVaccineCommand(string name, DateTime vaccinatedAt, bool firstVaccin, string? notes, Guid petId)
        {
            Name = name;
            VaccinatedAt = vaccinatedAt;
            FirstVaccin = firstVaccin;
            Notes = notes;
            PetId = petId;
        }

        public string Name { get; set; }
        public DateTime VaccinatedAt { get; set; }
        public bool FirstVaccin { get; set; }
        public string? Notes { get; set; } //in future could be a Entity, but now isn't necessary
        public Guid PetId { get; set; }

        public void Execute()
        {
            AddNotifications(new CustomContract<CreateVaccineCommand>()
                .CustomRequires()
                .IsGreaterOrEqualsThan(Name, 3, "The name needs to be greather than 3 char")
            );
        }
    }
}