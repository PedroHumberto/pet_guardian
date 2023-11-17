
using Flunt.Notifications;
using Flunt.Validations;
using PetGuadian.Application.Commands.Contracts;
using PetGuardian.Core.PetGuardianCore.Enums;
using PetGuardian.Models.Models;

namespace PetGuadian.Application.Commands.PetsCommand
{
    public class CreatePetCommand : Notifiable<Notification>, ICommand
    {
        public CreatePetCommand()
        {
        }

        public CreatePetCommand(string petName, char gender, AnimalSpecies specie, DateTime birthDate, float weight, Guid userId)
        {
            PetName = petName;
            Gender = gender;
            Specie = specie;
            BirthDate = birthDate;
            Weight = weight;
            UserId = userId;
        }

        public string PetName { get; set; }
        public char Gender { get; set; }
        public AnimalSpecies Specie { get; set; }
        public DateTime BirthDate { get; set; }
        public float Weight { get; set; }
        public Guid UserId { get; set; }


        public void Execute()
        {
            AddNotifications(new CustomContract<CreatePetCommand>()
                .CustomRequires()
                .IsGenderValid(Gender, "Gender is not correct try M or F")
                .IsGreaterOrEqualsThan(PetName, 3, "The name needs to be greather than 3 char")
            );
        }
    }
}