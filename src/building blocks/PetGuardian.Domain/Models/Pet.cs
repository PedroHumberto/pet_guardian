using PetGuardian.Domain.Core.DomainObjects;
using PetGuardian.Domain.Core.Enums;
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
        public AnimalSpecies Specie { get; private set; }
        public User User { get; private set; }
        public Guid UserId { get; private set; }
        public IEnumerable<PetExams>? PetExams { get; private set; }
        public Guid PetExamsId { get; private set; }

        protected Pet() { }

        public Pet(Guid petId, 
            string petName, 
            char gender, 
            AnimalSpecies specie
            )
        {
            Id = petId;
            PetName = petName;
            Gender = gender;
            Specie = specie;
        }

        public void AddExams(PetExams exam)
        {
            PetExams.Append(exam);
        }

    }
}