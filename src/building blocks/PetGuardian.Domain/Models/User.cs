using PetGuardian.Domain.Core.DomainObjects;

namespace PetGuardian.Models.Models
{
    public class User : Entity
    {
        
        public User(Guid UserId, string name, string email, string cpf, IEnumerable<Pet> pets)
        {
            Id = UserId;
            Name = name;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            Pets = pets;
            Deleted = false;
        }

        //EF Relation
        protected User() { }

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; set; }
        public IEnumerable<Pet>? Pets { get; private set; }
        public Address Address { get; private set; }
        public bool Deleted { get; private set; }


        public void ChangeAddress(Address address)
        {
            Address = address;
        }
        public void ChangeEmail(Email email)
        {
            Email = email;
        }

        public void AddPet(Pet pet)
        {
            Pets.Append(pet);
        }
    }
}