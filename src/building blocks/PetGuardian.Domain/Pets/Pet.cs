using PetGuardian.Core.Domain.Enums;
using PetGuardian.Domain.Abstractions;
using PetGuardian.Domain.Pets.Events;
using PetGuardian.Domain.Users;
using System.Globalization;


namespace PetGuardian.Domain.Pets
{
    public sealed class Pet : Entity
    {
        private Pet() { }

        private Pet(
            string petName,
            char gender,
            AnimalSpecies specie,
            DateTime birthDate,
            float? weight
            )
        {
            PetName = petName;
            Gender = gender;
            Specie = specie;
            BirthDate = birthDate;
            Weight = weight;
        }

        public string PetName { get; private set; }
        public char Gender { get; private set; }
        public AnimalSpecies Specie { get; private set; }
        public DateTime BirthDate { get; private set; }
        public float? Weight { get; private set; }
        public User User { get; private set; }
        public Guid UserId { get; private set; }
        public IEnumerable<Vaccine> Vaccines { get; private set; } = new List<Vaccine>();
        public IEnumerable<PetExam>? PetExams { get; private set; } = new List<PetExam>();
        public IEnumerable<Medicine>? Medicines { get; private set; } = new List<Medicine>();


        public static Pet Create(
            string petName,
            char gender,
            AnimalSpecies specie,
            DateTime birthDate,
            float? weight)
            {
                var pet = new Pet(petName, gender, specie, birthDate, weight);

                //RASE A COMMAND HERE
                pet.RaiseDomainEvent(new PetCreateDomainEvent(pet.Id));

                return pet;
            }

        public void Update(string name, char gender, DateTime birthDate, float? weight)
        {
            PetName = name;
            Gender = gender;
            BirthDate = birthDate;
            if (weight is null)
            {
                Weight = 0;
            }
            Weight = weight;

        }


        public void AddUser(Guid Id)
        {
            UserId = Id;
        }

        public int GetPetAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthDate.Year;
            // Verifique se o anivers�rio deste ano j� ocorreu.
            if (currentDate.Month < birthDate.Month || currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day)
            {
                age--;
            }

            return age;
        }

        public void BrFormattedBirthDate(DateTime birthDate)
        {
            string brazilFormattedDate = birthDate.ToString("dd/MM/yyyy");

            DateTime formattedDateTime = DateTime.ParseExact(brazilFormattedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            birthDate = formattedDateTime.Date;
        }

    }


}