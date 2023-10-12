using PetGuardian.Domain.Core.DomainObjects;

namespace PetGuardian.Models.Models
{
    public class PetExams : Entity
    {
        public PetExams(Guid examId, string examLink, string examName)
        {
            Id = examId;
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