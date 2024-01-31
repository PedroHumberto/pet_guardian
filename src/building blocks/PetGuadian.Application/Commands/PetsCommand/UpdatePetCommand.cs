
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

        public UpdatePetCommand(Guid userId, Guid petId, string petName, char gender, DateTime birthDate, long? weight)
        {
            UserId = userId;
            PetId = petId;
            PetName = petName;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
        }
        public Guid UserId {get; set;}
        public Guid PetId { get; set; }
        public string PetName { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public long? Weight { get; set; }

        public void Execute()
        {
                AddNotifications(new Contract<UpdatePetCommand>()
                .Requires()
                .IsGreaterThan(PetName, 1, "PetName", "Pet's Name needs to be greater than 1 char" )
            );
        }
    }
}