using PetGuardian.Core.PetGuardianCore.DomainObjects;

namespace PetGuardian.Domain.Models
{
    public class Vaccine : Entity
    {
        public Vaccine(string name, DateTime vaccinatedAt, bool firstVaccin, Guid petId, string? notes)
        {
            Name = name;
            VaccinatedAt = vaccinatedAt;
            FirstVaccin = firstVaccin;
            PetId = petId;
            Notes = notes;
        }

        protected Vaccine() {}

        public string Name { get; private set; }
        public DateTime VaccinatedAt { get; private set; }
        public bool FirstVaccin { get; private set; }
        public string? Notes { get; private set; } //in future could be a Entity, but now isn't necessary
        public Guid PetId { get; private set; }
        public Pet Pet {get; private set;}

        public void SetName(string _name){
            Name = _name;
        }
        public void SetNote(string _note){
            Notes = _note;
        }

    }
}