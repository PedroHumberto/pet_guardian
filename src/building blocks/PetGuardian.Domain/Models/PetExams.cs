using PetGuardian.Core.PetGuardianCore.DomainObjects;

namespace PetGuardian.Models.Models
{
    public class PetExams : Entity
    {
        public PetExams(string examLink, string examName)
        {
            ExamLink = examLink;
            ExamName = examName;
        }

        protected PetExams() { }

        public Pet Pet { get; private set; }
        public Guid petId { get; private set; }
        public string ExamLink { get; private set; }
        public string ExamName { get; private set; }
        
    }
}