using PetGuardian.Domain.Abstractions;
using PetGuardian.Domain.Pets;

namespace PetGuardian.Domain.Users
{
    public class User : Entity
    {
        private User(Guid? identityId, string firstName,string secondName, string email) : base(identityId)
        {
            FirstName = firstName;
            SecondName = secondName;
            Email = new Email(email);
            Deleted = false;
        }

        //EF Relation
        private User() { }

        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public Email Email { get; private set; }
        public IEnumerable<Pet>? Pets { get; private set; }
        public Address? Address { get; private set; }
        public bool Deleted { get; private set; }

        public static User Create(string firstName, string secondName, string email)
        {
            var user = new User(Guid.NewGuid(), firstName, secondName, email);

            return user;
        }
        public void AddPet(Pet pet)
        {
            if(pet is null)
            {
                throw new ArgumentNullException(nameof(pet));
            }
            Pets.Append(pet);
        }
    }
}