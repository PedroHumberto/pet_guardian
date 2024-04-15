using PetGuardian.Core.Exceptions;
using PetGuardian.Core.PetGuardianCore.DomainObjects;
using PetGuardian.Core.PetGuardianCore.Enums;
using System.Globalization;


namespace PetGuardian.Domain.Models
{
    public class Pet : Entity
    {
        public string PetName { get; private set; }
        public char Gender { get; private set; }
        public AnimalSpecies Specie { get; private set; }
        public DateTime BirthDate { get; private set; }
        public float? Weight { get; private set; }
        public User User { get; private set; }
        public Guid UserId { get; private set; }
        public IEnumerable<Vaccine> Vaccines {get; private set; }
        public IEnumerable<PetExam>? PetExams { get; private set; }
        public IEnumerable<Medicine>? Medicines { get; private set; }

        protected Pet() { }

        public Pet(
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

        public void AddMecine(Medicine medicine)
        {
            Medicines.Append(medicine);
        }
        public void AddVaccine(Vaccine vaccine)
        {
            Vaccines.Append(vaccine);
        }

        public void AddExams(PetExam exam)
        {
            if (exam.ExamLink is null)
            {
                CustomApplicationExceptions.ThrowIfObjectIsNull(exam, "AddExam", "PetExams is Null");
            }
            PetExams.Append(exam);
        }

        public void AddUser(Guid Id)
        {
            UserId = Id;
        }

        public int GetPetAge()
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - BirthDate.Year;
            
            if (currentDate.Month < BirthDate.Month || 
            (currentDate.Month == BirthDate.Month && 
            currentDate.Day < BirthDate.Day))
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