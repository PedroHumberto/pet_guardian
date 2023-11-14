
using Flunt.Notifications;
using Flunt.Validations;
using PetGuadian.Application.Commands.Contracts;

namespace PetGuadian.Application.Commands.PetsCommand
{
    public class UpdatePetCommand : Notifiable<Notification>, ICommand
    {
        public UpdatePetCommand()
        {
        }

        public UpdatePetCommand(Guid petId, string petName, char gender, DateTime birthDate, long? weight)
        {
            PetId = petId;
            PetName = petName;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
        }

        public Guid PetId { get; set; }
        public string PetName { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public long? Weight { get; set; }

        public void Execute()
        {
                AddNotifications(new Contract<UpdatePetCommand>()
                .Requires()
                .IsLowerOrEqualsThan(Gender, 1, "Gender", "Gender needs to be M or F")
                .IsGreaterThan(PetName, 3, "PetName", "Pet's Name needs to be greater than 3 char" )
            );
        }
    }
}