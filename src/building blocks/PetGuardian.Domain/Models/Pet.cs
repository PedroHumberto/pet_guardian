using PetGuardian.Core.PetGuardianCore.Enums;
using PetGuardian.Domain.Core.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuardian.Models.Models
{
    public class Pet : Entity, IAggregateRoot
    {
        public string PetName { get; private set; }
        public char Gender { get; private set; }
        public AnimalSpecies Specie { get; private set; }
        public DateTime BirthDate { get; private set; }
        public long? Weight { get; private set; }
        public User User { get; private set; }
        public Guid UserId { get; private set; }
        public IEnumerable<PetExams>? PetExams { get; private set; }

        protected Pet() { }

        public Pet(Guid petId, 
            string petName, 
            char gender, 
            AnimalSpecies specie,
            DateTime birthDate,
            long? weight
            )
        {
            Id = petId;
            PetName = petName;
            Gender = gender;
            Specie = specie;
            BirthDate = birthDate;
            Weight = weight;
        }

        public void AddExams(PetExams exam)
        {
            PetExams.Append(exam);
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
            if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
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