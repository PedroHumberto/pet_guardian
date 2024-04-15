using Flunt.Notifications;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.VaccineCommands
{
    public class UpdateVaccineCommand : Notifiable<Notification>, ICommand
    {
        public UpdateVaccineCommand(){}

        public UpdateVaccineCommand(Guid id, Guid petId, string name, string? notes)
        {
            Id = id;
            PetId = petId;
            Name = name;
            Notes = notes;
        }

        public Guid Id {get; set;}
        public Guid PetId { get; set; }
        public string Name { get; set; }
        public string? Notes { get; set; } //in future could be a Entity, but now isn't necessary

        public void Execute()
        {
            AddNotifications(new CustomContract<UpdateVaccineCommand>()
                .CustomRequires()
                .IsGreaterOrEqualsThan(Name, 3, "The name needs to be greather than 3 char")
            );
        }
    }
}