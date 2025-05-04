using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetGuardian.Core.DomainObjects;
using PetGuardian.Core.PetGuardianCore.DomainObjects;

namespace PetGuardian.Domain.Models
{
    public class Veterinarian : Entity
    {
        public Veterinarian( string firstName, string secondName, IEnumerable<Pet> petSharedList, CRVCode crvCode)
        {
            FirstName = firstName;
            SecondName = secondName;
            PetSharedList = petSharedList;
            CrvCode = crvCode;
        }

        protected Veterinarian(){}
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public IEnumerable<Pet> PetSharedList { get; private set; } = new List<Pet>();
        public CRVCode CrvCode { get; private set; }


        public void setPetShared(Pet pet)
        {
            if (pet is null)
            {
                return ;
            }
            PetSharedList.Append(pet);
        }
        
    }
}