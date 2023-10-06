using PetGuardian.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetGuardian.Models.Models
{
    public class Pet : Entity
    {
        public string PetName { get; private set; }
        public char Gender { get; private set; }
        public string Specie { get; private set; }
        public User PetGuadian { get; private set; }
        public Guid PetGuadianId { get; private set; }
        public IEnumerable<PetMedicalExam> PetExams { get; private set; }
        public Guid PetExamsId { get; private set; }

        public Pet(Guid petId, string petName, char gender, string specie, User petGuadian, Guid petGuadianId, IEnumerable<PetMedicalExam> petExams, Guid petExamsId)
        {
            Id = petId;
            PetName = petName;
            Gender = gender;
            Specie = specie;
            PetGuadian = petGuadian;
            PetGuadianId = petGuadianId;
            PetExams = petExams;
            PetExamsId = petExamsId;
        }

        public void AddExams(PetMedicalExam exam)
        {
            PetExams.Append(exam);
        }

    }
}